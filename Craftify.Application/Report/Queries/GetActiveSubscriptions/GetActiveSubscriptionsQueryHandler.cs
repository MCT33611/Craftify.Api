using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetActiveSubscriptions
{
    public class GetActiveSubscriptionsQueryHandler : IRequestHandler<GetActiveSubscriptionsQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActiveSubscriptionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetActiveSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var activeSubscriptions = _unitOfWork.Report.GetTotalNumberOfActiveSubscriptions();
            return new ReportResponse<int>
            {
                Data = activeSubscriptions,
                Message = "Total number of active subscriptions retrieved successfully."
            };
        }
    }
}
