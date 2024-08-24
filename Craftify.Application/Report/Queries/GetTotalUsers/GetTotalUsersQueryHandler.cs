using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalUsers
{
    public class GetTotalUsersQueryHandler : IRequestHandler<GetTotalUsersQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetTotalUsersQuery request, CancellationToken cancellationToken)
        {
            var totalUsers =  _unitOfWork.Report.GetTotalNumberOfUsers();
            return new ReportResponse<int>
            {
                Data = totalUsers,
                Message = "Total number of users retrieved successfully."
            };
        }
    }
}
