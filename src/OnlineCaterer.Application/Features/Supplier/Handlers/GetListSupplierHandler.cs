using AutoMapper;
using MediatR;
using OnlineCaterer.Application.Contracts.Identity.Services;
using OnlineCaterer.Application.Contracts.Persistence;
using OnlineCaterer.Application.DTOs.Supplier;
using OnlineCaterer.Application.Features.Supplier.Queries;
using OnlineCaterer.Application.Models.Api.Handler;
using OnlineCaterer.Application.Models.Api.Response;

namespace OnlineCaterer.Application.Features.Supplier.Handlers
{
	public class GetListSupplierHandler
		: GetListHandler<GetListSupplierQuery, SupplierDTO>,
		IRequestHandler<GetListSupplierQuery, ListResponse<SupplierDTO>>
	{

		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetListSupplierHandler(
			IPermissionProvider permissonProvider,
			IUserService userService,
			IUnitOfWork unitOfWork,
			IMapper mapper)
			: base(permissonProvider, userService)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public Task<ListResponse<SupplierDTO>> Handle(
			GetListSupplierQuery request, CancellationToken cancellationToken)
		{
			return GetResponse(request);
		}

		protected override async Task Resolve(
			GetListSupplierQuery request, ListResponse<SupplierDTO> response)
		{
			var suppliers = await _unitOfWork.SupplierRepository.GetAll();

			var foodEnum = suppliers.Select(s => s.Foods);
			foreach (var foodCol in foodEnum)
			{
				foodCol.Select(f => f.Id);
			}

			response.Payload = _mapper.Map<List<SupplierDTO>>(suppliers);
		}
	}
}
