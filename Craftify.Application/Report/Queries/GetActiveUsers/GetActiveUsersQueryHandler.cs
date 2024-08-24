using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetActiveUsers
{
    public class GetActiveUsersQueryHandler : IRequestHandler<GetActiveUsersQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActiveUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetActiveUsersQuery request, CancellationToken cancellationToken)
        {
            var activeUsers =  _unitOfWork.Report.GetTotalNumberOfActiveUsers();
            return new ReportResponse<int>
            {
                Data = activeUsers,
                Message = "Total number of active users retrieved successfully."
            };
        }
    }
}
