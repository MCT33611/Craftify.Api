using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalRevenueBySubscriptions
{
    public class GetTotalRevenueBySubscriptionsQueryHandler : IRequestHandler<GetTotalRevenueBySubscriptionsQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalRevenueBySubscriptionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetTotalRevenueBySubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var totalRevenue = _unitOfWork.Report.TotalRevenueBySubscriptions();
            return new ReportResponse<int>
            {
                Data = totalRevenue,
                Message = "Total revenue from all subscriptions retrieved successfully."
            };
        }
    }
}
