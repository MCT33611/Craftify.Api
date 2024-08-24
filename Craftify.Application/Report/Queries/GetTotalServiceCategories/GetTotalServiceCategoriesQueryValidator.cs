using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetTotalServiceCategories
{
    public class GetTotalServiceCategoriesQueryValidator : AbstractValidator<GetTotalServiceCategoriesQuery>
    {
        public GetTotalServiceCategoriesQueryValidator()
        {
            // Add any validation rules if needed
        }
    }
}
