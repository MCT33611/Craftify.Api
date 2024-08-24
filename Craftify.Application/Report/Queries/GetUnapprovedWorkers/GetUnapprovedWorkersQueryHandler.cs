using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetUnapprovedWorkers
{
    public class GetUnapprovedWorkersQueryHandler : IRequestHandler<GetUnapprovedWorkersQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUnapprovedWorkersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetUnapprovedWorkersQuery request, CancellationToken cancellationToken)
        {
            var unapprovedWorkers =  _unitOfWork.Report.GetTotalNumberOfUnapprovedWorkers();
            return new ReportResponse<int>
            {
                Data = unapprovedWorkers,
                Message = "Total number of unapproved workers retrieved successfully."
            };
        }
    }
}
