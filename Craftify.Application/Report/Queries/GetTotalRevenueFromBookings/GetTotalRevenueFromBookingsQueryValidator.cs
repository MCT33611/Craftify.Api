using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalRevenueFromBookings
{
    public class GetTotalRevenueFromBookingsQueryValidator : AbstractValidator<GetTotalRevenueFromBookingsQuery>
    {
        public GetTotalRevenueFromBookingsQueryValidator()
        {
            // Add any validation rules here if needed
        }
    }
}
