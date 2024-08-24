using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Craftify.Application.Notifications.Queries.SendEmail
{
    public class SendEmailQueryHandler : IRequestHandler<SendEmailQuery, bool>
    {
        private readonly IEmailSender _emailSender;

        public SendEmailQueryHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task<bool> Handle(SendEmailQuery request, CancellationToken cancellationToken)
        {
            await _emailSender.SendEmailAsync(request.To, request.Subject, request.HtmlMessage);
            return true;
        }
    }
}