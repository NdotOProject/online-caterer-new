using AutoMapper;
using OnlineCaterer.Application.DTOs.FoodImage;

namespace OnlineCaterer.Application.DTOs.Mappers
{
	public class FoodImageMapper : Profile
	{
		public FoodImageMapper()
		{
			CreateMap<Domain.Core.FoodImage, FoodImageDTO>();
		}
	}
}
