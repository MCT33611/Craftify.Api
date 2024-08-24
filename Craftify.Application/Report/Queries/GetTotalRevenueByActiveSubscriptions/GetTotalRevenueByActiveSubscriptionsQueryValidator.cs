using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalRevenueByActiveSubscriptions
{
    public class GetTotalRevenueByActiveSubscriptionsQueryValidator : AbstractValidator<GetTotalRevenueByActiveSubscriptionsQuery>
    {
        public GetTotalRevenueByActiveSubscriptionsQueryValidator()
        {
            // Add any validation rules if needed
        }
    }
}
