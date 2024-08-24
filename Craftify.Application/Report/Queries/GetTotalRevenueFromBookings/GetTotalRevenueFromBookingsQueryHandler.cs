using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;

namespace Craftify.Application.Report.Queries.GetTotalRevenueFromBookings
{
    public class GetTotalRevenueFromBookingsQueryHandler : IRequestHandler<GetTotalRevenueFromBookingsQuery, ReportResponse<decimal>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTotalRevenueFromBookingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<decimal>> Handle(GetTotalRevenueFromBookingsQuery request, CancellationToken cancellationToken)
        {
            var totalRevenue = _unitOfWork.Report.GetTotalRevenueFromBookings();

            return new ReportResponse<decimal>
            {
                Data = totalRevenue,
                Message = "Total revenue from bookings retrieved successfully."
            };
        }
    }
}