using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Request.Post;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity;
using OnlineCaterer.Domain.Core;
using System.Net;

namespace OnlineCaterer.Application.Features.Food.Create
{
	public class CreateFoodCommandHandler
		: PostRequestHandler<CreateFoodCommand, CreateFoodRequest>,
		IRequestHandler<CreateFoodCommand, VoidResponse>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateFoodCommandHandler(
			IPermissionProvider permissonProvider, IUserService userService,
			IMapper mapper, IUnitOfWork unitOfWork
		) : base(permissonProvider, userService)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<VoidResponse> Handle(
			CreateFoodCommand request, CancellationToken cancellationToken)
			=> await GetResponse(request);

		protected override async Task<Permission?> GetRequiredPermission(
			IPermissionProvider permissionProvider)
			=> await permissionProvider.GetPermission(Objects.Food, Actions.Create);

		protected override async Task Validate(CreateFoodCommand request, ErrorList errorList)
		{
			var validator = new CreateFoodRequestValidator(_unitOfWork);
			var validationResult = await validator.ValidateAsync(request.Body);
			var messages = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

			foreach (var message in messages)
			{
				errorList.Add(HttpStatusCode.BadRequest, message);
			}
		}

		protected override Task Reject(VoidResponse response)
		{
			response.Message = "Creation Failed!";
			return Task.CompletedTask;
		}

		protected override async Task Resolve(
			CreateFoodCommand request, VoidResponse response)
		{
			var food = _mapper.Map<Domain.Core.Food>(request.Body);

			food.RatingPoint = 0;
			food.Discontinued = false;
			food.CurrentQuantity = 0;

			List<FoodImage> images = request.Body.Images.ConvertAll(
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

			await _unitOfWork.SaveChanges(await GetUser());

			response.Message = $"The food with id {food.Id} has been created.";
			response.Id = food.Id;
		}
	}
}
