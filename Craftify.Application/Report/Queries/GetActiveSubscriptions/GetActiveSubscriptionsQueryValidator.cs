using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetActiveSubscriptions
{
    public class GetActiveSubscriptionsQueryValidator : AbstractValidator<GetActiveSubscriptionsQuery>
    {
        public GetActiveSubscriptionsQueryValidator()
        {
            // Add any validation rules if needed
        }
    }
}
