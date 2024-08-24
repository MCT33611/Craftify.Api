using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetNewUsersThisMonth
{
    public class GetNewUsersThisMonthQuery : IRequest<ReportResponse<int>>
    {
        // No parameters needed for this query
    }
}
