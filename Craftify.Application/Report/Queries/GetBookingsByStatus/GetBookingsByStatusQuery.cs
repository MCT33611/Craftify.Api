using Craftify.Application.Report.Common;
using Craftify.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetBookingsByStatus
{
    public class GetBookingsByStatusQuery : IRequest<ReportResponse<Dictionary<string, int>>>
    {
    }
}
