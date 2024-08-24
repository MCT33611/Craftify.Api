using Craftify.Application.Report.Common;
using MediatR;

namespace Craftify.Application.Report.Queries.GetTotalWorkers
{
    public class GetTotalWorkersQuery : IRequest<ReportResponse<int>>
    {
    }
}
