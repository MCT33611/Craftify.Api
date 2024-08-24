using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalSubscriptions
{
    public class GetTotalSubscriptionsQueryHandler : IRequestHandler<GetTotalSubscriptionsQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalSubscriptionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetTotalSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var totalSubscriptions =  _unitOfWork.Report.GetTotalNumberOfSubscriptions();
            return new ReportResponse<int>
            {
                Data = totalSubscriptions,
                Message = "Total number of subscriptions retrieved successfully."
            };
        }
    }
}
