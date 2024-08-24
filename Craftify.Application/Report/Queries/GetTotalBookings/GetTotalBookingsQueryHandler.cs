using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalBookings
{
    public class GetTotalBookingsQueryHandler : IRequestHandler<GetTotalBookingsQuery, ReportResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalBookingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<int>> Handle(GetTotalBookingsQuery request, CancellationToken cancellationToken)
        {
            var totalBookings =  _unitOfWork.Report.GetTotalNumberOfBookings();
            return new ReportResponse<int>
            {
                Data = totalBookings,
                Message = "Total number of bookings retrieved successfully."
            };
        }
    }
}
