using Craftify.Application.Report.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalRevenueBySubscriptions
{
    public record GetTotalRevenueBySubscriptionsQuery() : IRequest<ReportResponse<int>>;
}
