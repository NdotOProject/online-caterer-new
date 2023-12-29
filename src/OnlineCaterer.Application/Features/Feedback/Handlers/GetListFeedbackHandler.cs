using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.DTOs.Feedback;
using OnlineCaterer.Application.Features.Feedback.Queries;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using System.Net;

namespace OnlineCaterer.Application.Features.Feedback.Handlers
{
	public class GetListFeedbackHandler
		: GetListHandler<GetListFeedbackQuery, FeedbackDTO>,
		IRequestHandler<GetListFeedbackQuery, ListResponse<FeedbackDTO>>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public GetListFeedbackHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IUnitOfWork unitOfWork,
			IMapper mapper)
			: base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ListResponse<FeedbackDTO>> Handle(
			GetListFeedbackQuery request, CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			GetListFeedbackQuery request, ListResponse<FeedbackDTO> response)
		{
			var feedbacks = await _unitOfWork.FeedbackRepository
				.GetAll(fb => fb.FoodId == request.FoodId);

			response.Payload = _mapper.Map<List<FeedbackDTO>>(feedbacks);
		}

		protected override Task Reject(
			GetListFeedbackQuery request, ListResponse<FeedbackDTO> response)
		{
			response.Message = $"Get feedback on food with ID {request.FoodId} failed.";
			return Task.CompletedTask;
		}

		protected override async Task Validate(
			GetListFeedbackQuery request, ErrorList errorList)
		{
			var isExist = await _unitOfWork.FoodRepository
				.Contains(request.FoodId);

			if (!isExist)
			{
				errorList.Add(
					HttpStatusCode.BadRequest,
					$"Food with ID {request.FoodId} does not exist."
				);
			}
		}
	}
}
