using MediatR;
using OnlineCaterer.Application.DTOs.Food;
using OnlineCaterer.Application.Exceptions;
using OnlineCaterer.Application.Models.Api.Request;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Foods.Commands
{
	public class UpdateFoodCommand
		: IApiBodyRequest<UpdateFoodDTO>,
		IRequest<VoidResponse>
	{
		public int Id { get; set; }

		private UpdateFoodDTO _dto = null!;
		public UpdateFoodDTO Body
		{
			get
			{
				return _dto;
			}
			set
			{
				if (value != null && value.Id == Id)
				{
					_dto = value;
				}
				else
				{
					throw new BadRequestException();
				}
			}
		}
	}
}
