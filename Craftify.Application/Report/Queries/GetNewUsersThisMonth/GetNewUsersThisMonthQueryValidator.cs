using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetNewUsersThisMonth
{
    public class GetNewUsersThisMonthQueryValidator : AbstractValidator<GetNewUsersThisMonthQuery>
    {
        public GetNewUsersThisMonthQueryValidator()
        {
            // No validation rules needed for this query
        }
    }
}
