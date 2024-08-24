using Craftify.Application.Report.Common;
using MediatR;


namespace Craftify.Application.Report.Queries.GetTotalUsers
{
    public class GetTotalUsersQuery : IRequest<ReportResponse<int>>
    {
    }
}
