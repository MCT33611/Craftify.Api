using MediatR;
using Craftify.Domain.Entities;

namespace Craftify.Application.Notifications.Queries.GetUnreadNotifications
{
    public class GetUnreadNotificationsQuery : IRequest<List<Notification>>
    {
        public string UserId { get; }

        public GetUnreadNotificationsQuery(string userId)
        {
            UserId = userId;
        }
    }
}
