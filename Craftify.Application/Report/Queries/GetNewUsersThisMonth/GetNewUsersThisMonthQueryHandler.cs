using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetNewUsersThisMonth
{
    public class GetNewUsersThisMonthQueryHandler : IRequestHandler<GetNewUsersThisMonthQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetNewUsersThisMonthQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetNewUsersThisMonthQuery request, CancellationToken cancellationToken)
        {
            var newUsersCount = _unitOfWork.Report.GetTotalNumberOfNewUsersThisMonth();

            return new ReportResponse<int>
            {
                Data = newUsersCount,
                Message = "Number of new users this month retrieved successfully."
            };
        }
    }
}
