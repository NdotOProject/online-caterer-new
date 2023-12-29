using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Repositories.Core;
using OnlineCaterer.Application.Features.Feedback.Commands;
using OnlineCaterer.Application.Models.Api.Error;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;
using OnlineCaterer.Application.Models.Identity.Conventions;
using OnlineCaterer.Application.Models.Identity.Helper;
using System.Net;

namespace OnlineCaterer.Application.Features.Feedback.Handlers
{
	public class DeleteFeedbackHandler
		: DeleteHandler<DeleteFeedbackCommand>,
		IRequestHandler<DeleteFeedbackCommand, VoidResponse>
	{
		private readonly IFeedbackRepository _feedbackRepository;

		public DeleteFeedbackHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IFeedbackRepository feedbackRepository)
			: base(permissonProvider, userService)
		{
			_feedbackRepository = feedbackRepository;
		}

		public async Task<VoidResponse> Handle(
			DeleteFeedbackCommand request,
			CancellationToken cancellationToken)
		{
			return await GetResponse(request);
		}

		protected override async Task Resolve(
			DeleteFeedbackCommand request, VoidResponse response)
		{
			var feedback = await _feedbackRepository.Get(request.Id);

			_feedbackRepository.Delete(feedback);

			response.Id = feedback.Id;
			response.Message = $"Feedback with ID {request.Id} has been deleted.";
		}

		protected override Task Reject(
			DeleteFeedbackCommand request, VoidResponse response)
		{
			response.Message = $"Delete feedback with ID {request.Id} failed.";
			return Task.CompletedTask;
		}

		protected override async Task<Permission> GetPermission(
			IPermissionProvider provider)
		{
			return await provider.GetPermission(
				Objects.Feedback,
				Actions.Delete
			);
		}

		protected override async Task Validate(
			DeleteFeedbackCommand request, ErrorList errorList)
		{
			if (!await _feedbackRepository.Contains(request.Id))
			{
				errorList.Add(
					HttpStatusCode.NotFound,
					$"Feedback with ID {request.Id} does not exist."
				);
			}
		}
	}
}
