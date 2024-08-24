using FluentValidation;

namespace Craftify.Application.Notifications.Queries.GetUnreadNotifications
{
    public class GetUnreadNotificationsQueryValidator:AbstractValidator<GetUnreadNotificationsQuery>
    {
        public GetUnreadNotificationsQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();

        }

    }
}
