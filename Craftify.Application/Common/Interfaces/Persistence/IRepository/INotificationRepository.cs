using Craftify.Domain.Entities;
using Craftify.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Common.Interfaces.Persistence.IRepository
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetUnreadNotificationsAsync(string userId);
        Task<Notification> GetNotificationByIdAsync(int notificationId);
        Task AddNotificationAsync(Notification notification);
        Task MarkAsReadAsync(int notificationId);
        Task<List<Notification>> GetRecentNotificationsAsync(string userId, int count);
        Task DeleteNotificationAsync(int notificationId);
        Task<int> GetUnreadCountAsync(string userId);
        Task MarkAllAsReadAsync(string userId);
        Task<List<Notification>> GetNotificationsByTypeAsync(string userId, NotificationType type);
        Task<bool> HasUnreadNotificationsAsync(string userId);
    }
}
