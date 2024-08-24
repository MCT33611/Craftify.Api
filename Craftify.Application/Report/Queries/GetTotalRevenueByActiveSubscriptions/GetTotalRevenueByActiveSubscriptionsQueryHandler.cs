using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalRevenueByActiveSubscriptions
{
    public class GetTotalRevenueByActiveSubscriptionsQueryHandler : IRequestHandler<GetTotalRevenueByActiveSubscriptionsQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalRevenueByActiveSubscriptionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetTotalRevenueByActiveSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var totalRevenue = _unitOfWork.Report.TotalRevenueByActiveSubscriptions();
            return new ReportResponse<int>
            {
                Data = totalRevenue,
                Message = "Total revenue from active subscriptions retrieved successfully."
            };
        }
    }
}
