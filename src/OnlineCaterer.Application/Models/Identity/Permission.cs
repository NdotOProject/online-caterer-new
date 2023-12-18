using OnlineCaterer.Application.Contracts.Persistence;

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

		public static Permission? Find(IUnitOfWork unitOfWork, int objectId, int actionId)
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
			//unitOfWork.

			return null;
		}
	}
}
