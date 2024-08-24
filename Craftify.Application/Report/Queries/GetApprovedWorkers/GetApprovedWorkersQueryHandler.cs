using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetApprovedWorkers
{
    public class GetApprovedWorkersQueryHandler : IRequestHandler<GetApprovedWorkersQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetApprovedWorkersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetApprovedWorkersQuery request, CancellationToken cancellationToken)
        {
            var approvedWorkers =  _unitOfWork.Report.GetTotalNumberOfApprovedWorkers();
            return new ReportResponse<int>
            {
                Data = approvedWorkers,
                Message = "Total number of approved workers retrieved successfully."
            };
        }
    }
}
