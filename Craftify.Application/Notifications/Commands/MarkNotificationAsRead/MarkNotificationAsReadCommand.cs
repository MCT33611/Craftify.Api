using MediatR;

namespace Craftify.Application.Notifications.Commands.MarkNotificationAsRead
{
    public class MarkNotificationAsReadCommand : IRequest<Unit>
    {
        public int NotificationId { get; }

        public MarkNotificationAsReadCommand(int notificationId)
        {
            if (notificationId <= 0)
            {
                throw new ArgumentException("NotificationId must be greater than zero.", nameof(notificationId));
            }

            NotificationId = notificationId;
        }
    }
}
