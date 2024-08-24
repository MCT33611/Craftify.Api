﻿using Craftify.Application.Authentication.Commands.ConfirmEmail;
using Craftify.Application.Authentication.Commands.ForgotPassword;
using Craftify.Application.Authentication.Commands.Register;
using Craftify.Application.Authentication.Commands.LoginWithGoogle;
using Craftify.Application.Authentication.Commands.ResetPasswordCommand;
using Craftify.Application.Authentication.Common;
using Craftify.Application.Authentication.Queries.Login;
using Craftify.Application.Authentication.Queries.SendOtp;
using Craftify.Contracts.Authentication;
using Craftify.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Craftify.Application.Authentication.Commands.Refresh;

namespace Craftify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(
        ISender _mediator,
        IMapper _mapper
        ) : ApiController
    {
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshRequest request)
        {
            var query = _mapper.Map<RefreshCommand>(request);
            var authResult = await _mediator.Send(query);
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
                Problem
                );
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
        }

        [HttpPut("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailRequest request)
        {
            try
            {
                var command = new ConfirmEmailCommand(request.Email, request.OTP);
                ErrorOr<bool> result = await _mediator.Send(command);

                if (!result.IsError)
                {
                    return Ok(new { EmailConfirmation = true });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,$"An error occurred : {result.FirstError}");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            var authResult = await _mediator.Send(query);
            if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }
            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
                Problem
                );
        }

        [HttpPost("loginWithGoogle")]
        public async Task<IActionResult> LoginWithGoogle([FromBody] GoogleCredentialRequest request)
        {
            var command = new LoginWithGoogleCommand(request.IdToken);
            var authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
                Problem
                );
        }

        [HttpPost("forgotPassword/{Email}")]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            var command = new ForgotPasswordCommand(Email);
            var result = await _mediator.Send(command);

            return result.Match<IActionResult>(
                success => Ok(new { passwordResetToken = success }),
                error => NotFound(Errors.User.InvaildCredetial));
        }

        

        [HttpPut("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {
            if (model == null)
            {
                return BadRequest("Email, token, and new password are required for password reset.");
            }

            var command = _mapper.Map<ResetPasswordCommand>(model);
            var result = await _mediator.Send(command);

            if (result.Value)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Failed to reset password.");
            }
        }

        [HttpPost("sendOtp/{email}")]
        public async Task<IActionResult> SendOtp(string email)
        {
            var command = new SendOtpQuery(email);
            var result = await _mediator.Send(command);
            return result.Match<IActionResult>(
                success => Ok(new { OtpSent = success }),
                error => NotFound(Errors.User.InvaildCredetial));
        }


    }
}
