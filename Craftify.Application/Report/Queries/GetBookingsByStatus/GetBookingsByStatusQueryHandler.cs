using MediatR;
using Craftify.Application.Report.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Craftify.Application.Common.Interfaces.Persistence.IRepository;

namespace Craftify.Application.Report.Queries.GetBookingsByStatus
{
    public class GetBookingsByStatusQueryHandler
        : IRequestHandler<GetBookingsByStatusQuery, ReportResponse<Dictionary<string, int>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBookingsByStatusQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<Dictionary<string, int>>> Handle(
            GetBookingsByStatusQuery request,
            CancellationToken cancellationToken)
        {
            var bookingsByStatus =  _unitOfWork.Report.GetBookingsByStatus();
            return new ReportResponse<Dictionary<string, int>>
            {
                Data = bookingsByStatus,
                Message = "Bookings count by status retrieved successfully."
            };
        }
    }
}