using AutoMapper;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Contracts.Repositories.Identity;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Features.Auth.Login;
using OnlineCaterer.Application.Features.Auth.Register;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Persistence.Identity.Services
{
	public class AuthService : IAuthService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserService _userService;

		public AuthService(IUnitOfWork unitOfWork, IUserService userService)
		{
			_unitOfWork = unitOfWork;
			_userService = userService;
		}

		public async Task<LoginResponse?> Login(LoginRequest request)
		{
			try
			{
				var user = await _unitOfWork.UserRepository.Get(user => user.Email == request.Email);
				var result = PasswordHasher.VerifyHashedPassword(user, request.Password);
				return result
					? new LoginResponse
					{
						Id = user.Id,
						Email = request.Email,
						Username = user.UserName,
						UserType = user.UserTypeId,
					}
					: null;
			}
			catch (NotFoundException)
			{
				throw;
			}
		}

		public async Task<RegistrationResponse?> Register(RegistrationRequest request)
		{
			var user = new User
			{
				Email = request.Email,
				UserName = request.Email,
			};
			user = PasswordHasher.HashPassword(user, request.Password);

			var customer = new Customer
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Address = request.Address,
			};

			customer = await _unitOfWork.CustomerRepository.Add(customer);

			user.UserId = customer.Id;
			user.UserTypeId = _userService.GetUserTypeId(UserTypes.Customer);

			user = await _unitOfWork.UserRepository.Add(user);

			await _unitOfWork.SaveChanges(user);

			return new RegistrationResponse
			{
				UserId = customer.Id,
				UserType = user.UserTypeId,
			};
		}
	}
}
