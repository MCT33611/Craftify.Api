using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalServiceCategories
{
    public class GetTotalServiceCategoriesQueryHandler : IRequestHandler<GetTotalServiceCategoriesQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalServiceCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetTotalServiceCategoriesQuery request, CancellationToken cancellationToken)
        {
            var totalServiceCategories = _unitOfWork.Report.GetTotalNumberOfServiceCategories();
            return new ReportResponse<int>
            {
                Data = totalServiceCategories,
                Message = "Total number of service categories retrieved successfully."
            };
        }
    }
}
