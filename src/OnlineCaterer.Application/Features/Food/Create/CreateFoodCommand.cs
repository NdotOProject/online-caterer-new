using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Core;
using OnlineCaterer.Domain.Identity;

namespace OnlineCaterer.Application.Features.Food.Create
{
	public class CreateFoodCommand : IRequest<CommandResponse<CreateFoodResponse>>
	{
		public CreateFoodRequest CreateFoodRequest { get; set; } = null!;

		public class Handler : CommandHandler<CreateFoodRequest, CreateFoodResponse>,
			IRequestHandler<CreateFoodCommand, CommandResponse<CreateFoodResponse>>
		{
			private readonly IUnitOfWork _unitOfWork;
			private readonly IMapper _mapper;

			public Handler(
				IUnitOfWork unitOfWork,
				IMapper mapper,
				IPermissionProvider permissonProvider,
				IUserService userService
			) : base(
				userService,
				permissonProvider.GetPermission(Objects.Food, Actions.Create).Result
			)
			{
				_unitOfWork = unitOfWork;
				_mapper = mapper;
			}

			public async Task<CommandResponse<CreateFoodResponse>> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
			{
				await Execute(
					request.CreateFoodRequest,
					new CreateFoodRequest.Validator(_unitOfWork),
					cancellationToken
				);
				return Response;
			}

			protected override string Reject() => "Creation Failed!";

			protected override async Task<(
					string Message,
					CreateFoodResponse? Data,
					List<object>? Includes
				)> Resolve(CreateFoodRequest request)
			{
				var food = _mapper.Map<Domain.Core.Food>(request);

				food.RatingPoint = 0;
				food.Discontinued = false;
				food.CurrentQuantity = 0;

				List<FoodImage> images = request.Images.ConvertAll(
					img => new FoodImage
					{
						Name = img,
						Food = food,
						FoodId = food.Id,
					}
				);

				food.Images = images;

				food = await _unitOfWork.FoodRepository.Add(food);
				await _unitOfWork.FoodImageRepository.AddRange(images);

				await _unitOfWork.Commit(User.Id);

				return (
					Message: $"The food with id {food.Id} has been created.",
					Data: new CreateFoodResponse
					{
						Id = food.Id,
					},
					Includes: null
				);
			}
		}
	}
}
