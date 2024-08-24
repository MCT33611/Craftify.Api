using Craftify.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Notifications.Commands.AddNotification
{
    public class AddNotificationCommand : IRequest<Unit>
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public string UserId { get; set; }
        public string SenderId { get; set; }
        public NotificationType Type { get; set; }
    }
}
