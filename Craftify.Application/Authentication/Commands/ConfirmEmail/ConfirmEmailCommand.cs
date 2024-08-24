﻿using ErrorOr;
using MediatR;

namespace Craftify.Application.Authentication.Commands.ConfirmEmail
{
    public record ConfirmEmailCommand(
        string Email,
        string OTP
        ):IRequest<ErrorOr<bool>>;
}
