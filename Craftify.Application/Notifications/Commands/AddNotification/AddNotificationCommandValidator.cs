using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Notifications.Commands.AddNotification
{
    public class AddNotificationCommandValidator : AbstractValidator<AddNotificationCommand>
    {
        public AddNotificationCommandValidator()
        {
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.IsRead).NotEmpty();
            RuleFor(x => x.Timestamp).NotEmpty();
            RuleFor(x => x.SenderId).NotEmpty();
            RuleFor(x => x.Subject).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
