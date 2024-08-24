using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetBlockedUsers
{
    public class GetBlockedUsersQueryHandler : IRequestHandler<GetBlockedUsersQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBlockedUsersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetBlockedUsersQuery request, CancellationToken cancellationToken)
        {
            var blockedUsers =  _unitOfWork.Report.GetTotalNumberOfBlockedUsers();
            return new ReportResponse<int>
            {
                Data = blockedUsers,
                Message = "Total number of blocked users retrieved successfully."
            };
        }
    }
}
