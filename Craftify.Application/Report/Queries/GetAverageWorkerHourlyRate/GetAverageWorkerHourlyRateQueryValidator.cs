﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Report.Queries.GetAverageWorkerHourlyRate
{
    public class GetAverageWorkerHourlyRateQueryValidator : AbstractValidator<GetAverageWorkerHourlyRateQuery>
    {
        public GetAverageWorkerHourlyRateQueryValidator()
        {
            // Add any validation rules if needed
        }
    }
}
