using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Craftify.Application.Notifications.Queries.SendEmail
{
    public class SendEmailQuery : IRequest<bool>
    {
        [Required]
        [EmailAddress]
        public string To { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string HtmlMessage { get; set; }
    }
}