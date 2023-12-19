using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Exceptions;

namespace OnlineCaterer.Application.Models.Identity
{
	public class Permission
	{
		private Permission(
			Domain.Identity.Action action,
			Domain.Identity.Object obj)
		{
			Action = action;
			Object = obj;
		}

		public Domain.Identity.Action Action { get; }
		public Domain.Identity.Object Object { get; }

		public static Permission From(Domain.Identity.Object obj, Domain.Identity.Action action)
		{
			return new Permission(action, obj);
		}

		public static async Task<Permission> Find(IUnitOfWork unitOfWork, int objectId, int actionId)
		{
			if (unitOfWork == null)
			{
				throw new ArgumentNullException(nameof(unitOfWork));
			}
			if (objectId < 0)
			{
				throw new InvalidDataException($"{nameof(objectId)} must greater than 0.");
			}
			if (actionId < 0)
			{
				throw new InvalidDataException($"{nameof(actionId)} must greater than 0.");
			}

			try
			{
				Domain.Identity.Object obj = await unitOfWork.ObjectRepository.Get(objectId);
				Domain.Identity.Action act = await unitOfWork.ActionRepository.Get(actionId);

				return new Permission(act, obj);
			}
			catch(NotFoundException)
			{
				throw;
			}
		}
	}
}
