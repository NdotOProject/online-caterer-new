using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Domain.Identity.Relationship;
using System.Collections.Immutable;

namespace OnlineCaterer.Application.Models.Identity.Helper
{
	public class Permission
	{
		private static readonly Domain.Identity.Action _noneAction =
			new()
			{
				Id = 0,
				Name = "None",
				Groups = ImmutableList<GroupPermission>.Empty,
				Users = ImmutableList<UserPermission>.Empty
			};

		private static readonly Domain.Identity.Object _noneObject =
			new()
			{
				Id = 0,
				Name = "None",
				Groups = ImmutableList<GroupPermission>.Empty,
				Users = ImmutableList<UserPermission>.Empty
			};

		private static volatile Permission? _optional;

		private Permission(
			Domain.Identity.Action action,
			Domain.Identity.Object obj)
		{
			Action = action;
			Object = obj;
		}

		public Domain.Identity.Action Action { get; }
		public Domain.Identity.Object Object { get; }

		public static Permission Optional
		{
			get
			{
				if (_optional == null)
				{
					lock (typeof(Permission))
					{
						_optional ??= new Permission(
							_noneAction, _noneObject
						);
					}
				}
				return _optional;
			}
		}

		public static Permission From(
			Domain.Identity.Object obj, Domain.Identity.Action action)
		{
			if (obj == _noneObject)
			{
				throw new ArgumentOutOfRangeException(nameof(obj));
			}

			if (action == _noneAction)
			{
				throw new ArgumentOutOfRangeException(nameof(action));
			}

			return new Permission(action, obj);
		}

		public static async Task<Permission> Find(
			IUnitOfWork unitOfWork, int objectId, int actionId)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}

			if (objectId < 0)
			{
				throw new InvalidDataException(
					$"{nameof(objectId)} must greater than 0.");
			}

			if (actionId < 0)
			{
				throw new InvalidDataException(
					$"{nameof(actionId)} must greater than 0.");
			}

			try
			{
				var obj = await unitOfWork.ObjectRepository.Get(objectId);
				var act = await unitOfWork.ActionRepository.Get(actionId);

				return From(obj, act);
			}
			catch
			{
				throw;
			}
		}
	}
}
