using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.Models;
using OnlineCaterer.Application.Models.Identity;

namespace OnlineCaterer.Application.Features.Food.Update
{
	public class UpdateFoodCommand : IRequest<CommandResponse<UpdateFoodResponse>>
	{
		public UpdateFoodRequest UpdateFoodRequest { get; set; } = null!;

		public class Handler : CommandHandler<UpdateFoodRequest, UpdateFoodResponse>,
			IRequestHandler<UpdateFoodCommand, CommandResponse<UpdateFoodResponse>>
		{
			private readonly IUnitOfWork _unitOfWork;
			private readonly IMapper _mapper;

			public Handler(
				IUnitOfWork unitOfWork,
				IMapper mapper,
				IUserService userService,
				IPermissionProvider permissionProvider
			) : base(
				userService,
				permissionProvider.GetPermission(Objects.Food, Actions.Update).Result
			)
			{
				_unitOfWork = unitOfWork;
				_mapper = mapper;
			}

			public async Task<CommandResponse<UpdateFoodResponse>> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
			{
				await Execute(request.UpdateFoodRequest, new UpdateFoodRequest.Validator(_unitOfWork), cancellationToken);
				return Response;
			}

			protected override string Reject() => "Update Failed!";

			protected override async Task<(
					string Message,
					UpdateFoodResponse? Data,
					List<object>? Includes
				)> Resolve(UpdateFoodRequest request)
			{
				var food = _mapper.Map<Domain.Core.Food>(request);
				_unitOfWork.FoodRepository.Update(food);

				await _unitOfWork.Commit(User.Id);

				return ("Updated.", new UpdateFoodResponse(), null);
			}
		}
	}
}
