﻿using Craftify.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Profile.Commands.UpdateServiceProvider
{
    public record UpdateServiceProviderCommand(Guid Id, Worker Model) : IRequest<ErrorOr<Unit>>;
}
