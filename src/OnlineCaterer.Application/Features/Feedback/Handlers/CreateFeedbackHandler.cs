using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.DTOs.Feedback;
using OnlineCaterer.Application.DTOs.Feedback.Validators;
using OnlineCaterer.Application.Features.Feedback.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using System.Net;

namespace OnlineCaterer.Application.Features.Feedback.Handlers
{
	public class CreateFeedbackHandler
		: PostHandler<CreateFeedbackCommand, CreateFeedbackDTO>,
		IRequestHandler<CreateFeedbackCommand, VoidResponse>
	{
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;

		public CreateFeedbackHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IUnitOfWork unitOfWork,
			IMapper mapper)
			: base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<VoidResponse> Handle(
			CreateFeedbackCommand request,
			CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			CreateFeedbackCommand request, VoidResponse response)
		{
			var feedback = _mapper.Map<Domain.Core.Feedback>(request.Body);

			feedback = await _unitOfWork.FeedbackRepository.Add(feedback);

			response.Id = feedback.Id;
			response.Message = "Created new feedback successfully.";
		}

		protected override Task Reject(
			CreateFeedbackCommand request, VoidResponse response)
		{
			response.Message = "An error occurred while creating the feedback.";
			return Task.CompletedTask;
		}

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.Feedback,
				Actions.Create
			);
		}

		protected override async Task Validate(
			CreateFeedbackCommand request, ErrorList errorList)
		{
			var validator = new CreateFeedbackValidator(_unitOfWork);
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
