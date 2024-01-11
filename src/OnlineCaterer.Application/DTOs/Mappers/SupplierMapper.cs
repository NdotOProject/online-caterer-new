using AutoMapper;
using OnlineCaterer.Application.DTOs.Supplier;

namespace OnlineCaterer.Application.DTOs.Mappers
{
	public class SupplierMapper : Profile
	{
		public SupplierMapper()
		{
			CreateMap<Domain.Core.Supplier, SupplierDTO>()
				.ForMember(dto => dto.Foods, config => config.MapFrom(s => s.Foods));
		}
	}
}
