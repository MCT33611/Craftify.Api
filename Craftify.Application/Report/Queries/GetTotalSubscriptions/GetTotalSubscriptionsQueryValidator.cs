using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalSubscriptions
{
    public class GetTotalSubscriptionsQueryValidator : AbstractValidator<GetTotalSubscriptionsQuery>
    {
        public GetTotalSubscriptionsQueryValidator()
        {
            // No specific validation rules for this query
            // You can add rules if you decide to add parameters to the query in the future
        }
    }
}
