using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Domain.Entities;
using Craftify.Domain.Enums;
using Craftify.Infrastructure.Persistence.Repository;
using Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Infrastructure.Presistence.Repository
{
    public class NotificationRepository :Repository<Notification> ,INotificationRepository
    {
        private readonly CraftifyDbContext _context;

        public NotificationRepository(CraftifyDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<Notification>> GetUnreadNotificationsAsync(string userId)
        {
            return _context.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .OrderByDescending(n => n.Timestamp)
                .ToList();
        }

        public async Task<Notification> GetNotificationByIdAsync(int notificationId)
        {
            return await _context.Notifications.FindAsync(notificationId);
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }

        public async Task MarkAsReadAsync(int notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Notification>> GetRecentNotificationsAsync(string userId, int count)
        {
            return _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.Timestamp)
                .Take(count)
                .ToList();
        }

        public async Task DeleteNotificationAsync(int notificationId)
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetUnreadCountAsync(string userId)
        {
            return  _context.Notifications
                .Count(n => n.UserId == userId && !n.IsRead);
        }

        public async Task MarkAllAsReadAsync(string userId)
        {
            var unreadNotifications =  _context.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .ToList();

            foreach (var notification in unreadNotifications)
            {
                notification.IsRead = true;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Notification>> GetNotificationsByTypeAsync(string userId, NotificationType type)
        {
            return  _context.Notifications
                .Where(n => n.UserId == userId && n.Type == type)
                .OrderByDescending(n => n.Timestamp)
                .ToList();
        }

        public async Task<bool> HasUnreadNotificationsAsync(string userId)
        {
            return  _context.Notifications
                .Any(n => n.UserId == userId && !n.IsRead);
        }
    }
}
