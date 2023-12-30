using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.DTOs.Food;
using OnlineCaterer.Application.DTOs.Food.Validators;
using OnlineCaterer.Application.Features.Foods.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using System.Net;

namespace OnlineCaterer.Application.Features.Foods.Handlers
{
	// insert food => insert image
	public class CreateFoodCommandHandler
		: PostHandler<CreateFoodCommand, CreateFoodDTO>,
		IRequestHandler<CreateFoodCommand, VoidResponse>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateFoodCommandHandler(
			IPermissionProvider permissonProvider, IUserService userService,
			IMapper mapper, IUnitOfWork unitOfWork)
			: base(permissonProvider, userService)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<VoidResponse> Handle(
			CreateFoodCommand request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			CreateFoodCommand request, VoidResponse response)
		{
			var food = _mapper.Map<Domain.Core.Food>(request.Body);

			foreach (var image in food.Images)
			{
				image.Food = food;
				image.FoodId = food.Id;
			}

			food = await _unitOfWork.FoodRepository.Add(food);
			await _unitOfWork.FoodImageRepository.AddRange(food.Images);

			await _unitOfWork.SaveChanges(await GetUser());

			response.Message = $"The food with id {food.Id} has been created.";
			response.Id = food.Id;
		}

		protected override Task Reject(
			CreateFoodCommand request, VoidResponse response)
		{
			response.Message = "Creation Failed!";
			return Task.CompletedTask;
		}

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.Food,
				Actions.Create
			);
		}

		protected override async Task Validate(
			CreateFoodCommand request, ErrorList errorList)
		{
			var validator = new CreateFoodValidator(_unitOfWork);
			var validationResult = await validator.ValidateAsync(request.Body);

			foreach (var message in validationResult.Errors.Select(e => e.ErrorMessage))
			{
				errorList.Add(HttpStatusCode.BadRequest, message);
			}
		}
	}
}
