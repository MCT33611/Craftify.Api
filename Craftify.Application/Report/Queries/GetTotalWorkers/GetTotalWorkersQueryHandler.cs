using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalWorkers
{
    public class GetTotalWorkersQueryHandler : IRequestHandler<GetTotalWorkersQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalWorkersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetTotalWorkersQuery request, CancellationToken cancellationToken)
        {
            var totalWorkers =  _unitOfWork.Report.GetTotalNumberOfWorkers();
            return new ReportResponse<int>
            {
                Data = totalWorkers,
                Message = "Total number of workers retrieved successfully."
            };
        }
    }
}
