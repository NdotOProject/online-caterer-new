using AutoMapper;
using OnlineCaterer.Application.Features.Customers.Requests;
using OnlineCaterer.Domain.Core;

namespace OnlineCaterer.Application.Features.Events.Mappers
{
	public class UpdateEventMapper : Profile
	{
		public UpdateEventMapper()
		{
			CreateMap<UpdateCustomerRequest, Customer>();
		}
	}
}
