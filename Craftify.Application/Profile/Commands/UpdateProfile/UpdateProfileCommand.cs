﻿using Craftify.Domain.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Profile.Commands.UpdateProfile
{
    public record UpdateProfileCommand(Guid Id, User Model) : IRequest<ErrorOr<Unit>>;
}
