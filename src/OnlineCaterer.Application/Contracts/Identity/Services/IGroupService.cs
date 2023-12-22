using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Contracts.Identity.Services
{
	public interface IGroupService
	{
		Task<ICollection<Group>> GetGroupsByUserType(int userTypeId);
	}
}
