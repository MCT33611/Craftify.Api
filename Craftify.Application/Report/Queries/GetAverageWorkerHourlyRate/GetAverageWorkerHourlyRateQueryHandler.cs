using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Application.Report.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetAverageWorkerHourlyRate
{
    public class GetAverageWorkerHourlyRateQueryHandler : IRequestHandler<GetAverageWorkerHourlyRateQuery, ReportResponse<decimal>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAverageWorkerHourlyRateQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReportResponse<decimal>> Handle(GetAverageWorkerHourlyRateQuery request, CancellationToken cancellationToken)
        {
            var averageHourlyRate = _unitOfWork.Report.GetAverageWorkerHourlyRate();
            return new ReportResponse<decimal>
            {
                Data = averageHourlyRate,
                Message = "Average worker hourly rate retrieved successfully."
            };
        }
    }
}
