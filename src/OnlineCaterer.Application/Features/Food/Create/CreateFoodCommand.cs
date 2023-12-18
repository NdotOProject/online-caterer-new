using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using OnlineCaterer.Application.Constants;
using OnlineCaterer.Application.Contracts.Identity;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Contracts.Services;
using OnlineCaterer.Application.Models;
using OnlineCaterer.Domain.Core;
using System.Net;

namespace OnlineCaterer.Application.Features.Food.Create
{
	public class CreateFoodCommand : IRequest<CommandResponse<CreateFoodResponse>>
	{
		public CreateFoodRequest CreateFoodRequest { get; set; } = null!;

		public class Handler : IRequestHandler<CreateFoodCommand, CommandResponse<CreateFoodResponse>>
		{
			private readonly IUnitOfWork _unitOfWork;
			private readonly IHttpContextAccessor _httpContextAccessor;
			private readonly IMapper _mapper;
			private readonly IPermissionCollection _permissionCollection;
			private readonly IUserService _userService;

			public Handler(
				IUnitOfWork unitOfWork,
				IHttpContextAccessor httpContextAccessor,
				IMapper mapper,
				IPermissionCollection permissionCollection,
				IUserService userService)
			{
				_unitOfWork = unitOfWork;
				_httpContextAccessor = httpContextAccessor;
				_mapper = mapper;
				_permissionCollection = permissionCollection;
				_userService = userService;
			}

			public async Task<CommandResponse<CreateFoodResponse>> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
			{
				var response = new CommandResponse<CreateFoodResponse>();
				var validator = new CreateFoodRequest.Validator(_unitOfWork);
				ValidationResult validationResult = await validator.ValidateAsync(request.CreateFoodRequest, cancellationToken);

				int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
					q => q.Type == CustomClaimTypes.Uid)?.Value);

				var permissions = _unitOfWork.UserRepository.GetPermissions(userId);
				if (!permissions.Contains(_permissionCollection.CreateFoodPermission))
				{
					validationResult.Errors.Add(
						new ValidationFailure
						{
							ErrorMessage = "Ban khong co quyen tao moi mon an.",
							ErrorCode = HttpStatusCode.Forbidden.ToString(),
						}
					);
				}

				if (validationResult.IsValid)
				{
					var food = _mapper.Map<Domain.Core.Food>(request.CreateFoodRequest);

					food.RatingPoint = 0;
					food.Discontinued = false;
					food.CurrentQuantity = 0;

					List<FoodImage> images = request.CreateFoodRequest.Images.ConvertAll(
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

					await _unitOfWork.Commit(userId);

					response.Success = true;
					response.Message = "Creation Successful";
					response.Data = new CreateFoodResponse
					{
						CreatedFoodId = food.Id
					};
				}
				else
				{
					response.Success = false;
					response.Message = "Request Failed!";
					response.Errors = validationResult?.Errors.Select(x => x.ErrorMessage).ToList();
				}

				return response;
			}
		}
	}
}
