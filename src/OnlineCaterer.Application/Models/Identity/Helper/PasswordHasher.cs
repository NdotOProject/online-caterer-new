using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using OnlineCaterer.Domain.Identity;
using System.Security.Cryptography;
using System.Text;

namespace OnlineCaterer.Application.Models.Identity.Helper
{
	public class PasswordHasher
	{
		private const int SaltSize = 128 / 8; // 128 bits
		private const int Pbkdf2IterCount = 1000;
		private const int Pbkdf2SubkeyLength = 256 / 8; // 256 bits
		private const KeyDerivationPrf Prf = KeyDerivationPrf.HMACSHA256;

		public static User HashPassword(User user, string password)
		{
			string email = user.Email;
			if (password == null)
			{
				throw new ArgumentNullException(nameof(password));
			}

			byte[] salt = new byte[SaltSize];
			using (var rngCsp = RandomNumberGenerator.Create())
			{
				rngCsp.GetBytes(salt);
			}

			byte[] subkey = KeyDerivation.Pbkdf2(
				password: password,
				salt: salt,
				prf: Prf,
				iterationCount: Pbkdf2IterCount,
				numBytesRequested: Pbkdf2SubkeyLength
			);

			var output = new byte[
				13 + email.Length + salt.Length + subkey.Length
			];
			output[0] = 0x01;

			WriteNetworkByteOrder(output, 1, (uint)Prf);
			WriteNetworkByteOrder(output, 5, Pbkdf2IterCount);
			WriteNetworkByteOrder(output, 9, SaltSize);

			Buffer.BlockCopy(
				Encoding.ASCII.GetBytes(email),
				0,
				output,
				13,
				email.Length
			);
			Buffer.BlockCopy(
				salt,
				0,
				output,
				13 + email.Length,
				salt.Length
			);
			Buffer.BlockCopy(
				subkey,
				0,
				output,
				13 + email.Length + SaltSize,
				subkey.Length
			);

			user.Password = Convert.ToBase64String(output);
			return user;
		}

		public static bool VerifyHashedPassword(User user, string password)
		{
			byte[] decodedHashedPassword = Convert.FromBase64String(user.Password);
			try
			{
				string email = user.Email;

				int saltLength = (int)ReadNetworkByteOrder(decodedHashedPassword, 9);

				byte[] emailChars = new byte[email.Length];

				Buffer.BlockCopy(
					decodedHashedPassword,
					13,
					emailChars,
					0,
					emailChars.Length
				);

				if (!Encoding.ASCII.GetString(emailChars).Equals(email))
				{
					return false;
				}

				if (saltLength < 128 / 8)
				{
					return false;
				}

				byte[] salt = new byte[saltLength];

				Buffer.BlockCopy(
					decodedHashedPassword,
					13 + email.Length,
					salt,
					0,
					salt.Length
				);

				int subkeyLength =
					decodedHashedPassword.Length - 13 - salt.Length - email.Length;

				if (subkeyLength < 128 / 8)
				{
					return false;
				}

				byte[] expectedSubkey = new byte[subkeyLength];

				Buffer.BlockCopy(
					decodedHashedPassword,
					13 + email.Length + salt.Length,
					expectedSubkey,
					0,
					expectedSubkey.Length
				);

				byte[] actualSubkey = KeyDerivation.Pbkdf2(
					password,
					salt,
					Prf,
					Pbkdf2IterCount,
					subkeyLength
				);

				return CryptographicOperations.FixedTimeEquals(
					actualSubkey, expectedSubkey
				);
			}
			catch
			{
				return false;
			}
		}

		private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
		{
			return (uint)buffer[offset + 0] << 24
				| (uint)buffer[offset + 1] << 16
				| (uint)buffer[offset + 2] << 8
				| buffer[offset + 3];
		}

		private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
		{
			buffer[offset + 0] = (byte)(value >> 24);
			buffer[offset + 1] = (byte)(value >> 16);
			buffer[offset + 2] = (byte)(value >> 8);
			buffer[offset + 3] = (byte)(value >> 0);
		}
	}
}
