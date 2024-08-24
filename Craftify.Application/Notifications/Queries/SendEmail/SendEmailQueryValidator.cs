using FluentValidation;

namespace Craftify.Application.Notifications.Queries.SendEmail
{
    public class SendEmailQueryValidator : AbstractValidator<SendEmailQuery>
    {
        public SendEmailQueryValidator()
        {
            RuleFor(x => x.To)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("A valid email address is required.");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Subject is required.")
                .MaximumLength(100).WithMessage("Subject must not exceed 100 characters.");

            RuleFor(x => x.HtmlMessage)
                .NotEmpty().WithMessage("Message body is required.")
                .MaximumLength(10000).WithMessage("Message body must not exceed 10000 characters.");
        }
    }
}