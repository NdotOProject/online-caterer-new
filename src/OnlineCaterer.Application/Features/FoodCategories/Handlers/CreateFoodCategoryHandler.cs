using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.DTOs.FoodCategory;
using OnlineCaterer.Application.DTOs.FoodCategory.Validators;
using OnlineCaterer.Application.Features.FoodCategories.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using System.Net;

namespace OnlineCaterer.Application.Features.FoodCategories.Handlers
{
	public class CreateFoodCategoryHandler
		: PostHandler<CreateFoodCategoryCommand, CreateFoodCategoryDTO>,
		IRequestHandler<CreateFoodCategoryCommand, VoidResponse>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateFoodCategoryHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IMapper mapper,
			IUnitOfWork unitOfWork)
			: base(permissonProvider, userService)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<VoidResponse> Handle(
			CreateFoodCategoryCommand request,
			CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			CreateFoodCategoryCommand request, VoidResponse response)
		{
			var foodCategory = _mapper
				.Map<Domain.Core.FoodCategory>(request.Body);

			foodCategory = await _unitOfWork
				.FoodCategoryRepository.Add(foodCategory);

			response.Id = foodCategory.Id;
			response.Message = "Created new category successfully.";
		}

		protected override Task Reject(
			CreateFoodCategoryCommand request, VoidResponse response)
		{
			response.Message = "An error occurred while creating the category.";
			return Task.CompletedTask;
		}

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.FoodCategory,
				Actions.Create
			);
		}

		protected override async Task Validate(
			CreateFoodCategoryCommand request, ErrorList errorList)
		{
			var validator = new CreateFoodCategoryValidator();
			var result = await validator.ValidateAsync(request.Body);

			if (!result.IsValid)
			{
				foreach (var error in result.Errors)
				{
					errorList.Add(
						HttpStatusCode.BadRequest,
						error.ErrorMessage
					);
				}
			}
		}
	}
}
