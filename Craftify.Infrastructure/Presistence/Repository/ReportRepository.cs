using Craftify.Application.Common.Interfaces.Persistence;
using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Domain.Entities;
using Craftify.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Craftify.Infrastructure.Presistence.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly CraftifyDbContext _db;

        public ReportRepository(CraftifyDbContext db)
        {
            _db = db;
        }


        public int GetTotalNumberOfUsers()
        {
            return _db.Users.Count();
        }

        public int GetTotalNumberOfActiveUsers()
        {
            return _db.Users.Count(u => !u.Blocked);
        }

        public int GetTotalNumberOfBlockedUsers()
        {
            return _db.Users.Count(u => u.Blocked);
        }

        public int GetTotalNumberOfWorkers()
        {
            return _db.Workers.Count();
        }

        public int GetTotalNumberOfApprovedWorkers()
        {
            return _db.Workers.Count(w => w.Approved);
        }

        public int GetTotalNumberOfUnapprovedWorkers()
        {
            return _db.Workers.Count(w => !w.Approved);
        }

        public int GetTotalNumberOfBookings()
        {
            return _db.Bookings.Count();
        }

        public int GetTotalNumberOfPendingBookings()
        {
            return _db.Bookings.Count(b => b.Status == BookingStatus.Pending);
        }

        public int GetTotalNumberOfCompletedBookings()
        {
            return _db.Bookings.Count(b => b.Status == BookingStatus.Completed);
        }

        public int GetTotalNumberOfCancelledBookings()
        {
            return _db.Bookings.Count(b => b.Status == BookingStatus.Cancelled);
        }

        public int GetTotalNumberOfRejectedBookings()
        {
            return _db.Bookings.Count(b => b.Status == BookingStatus.Rejected);
        }

        public int GetTotalNumberOfAcceptedBookings()
        {
            return _db.Bookings.Count(b => b.Status == BookingStatus.Accepted);
        }

        public int GetTotalNumberOfSubscriptions()
        {
            return _db.Subscriptions.Count();
        }

        public int GetTotalNumberOfActiveSubscriptions()
        {
            return _db.Subscriptions.Count(s => s.ExpireAt > DateTime.UtcNow);
        }

        public int TotalRevenueBySubscriptions()
        {
            int revenue = 0;

            revenue = _db.Subscriptions
                         .Include(s => s.Plan)
                         .Sum(s => s.Plan.Price.HasValue ? (int)s.Plan.Price.Value : 0);

            return revenue;
        }

        public int TotalRevenueByActiveSubscriptions()
        {
            int revenue = 0;

            revenue = _db.Subscriptions
                         .Where(s => s.ExpireAt > DateTime.UtcNow)
                         .Include(s => s.Plan)
                         .Sum(s => s.Plan.Price.HasValue ? (int)s.Plan.Price.Value : 0);

            return revenue;
        }

        public decimal GetAverageWorkerHourlyRate()
        {
            return _db.Workers.Average(w => w.PerHourPrice);
        }

        public int GetTotalNumberOfServiceCategories()
        {
            return _db.Workers.Select(w => w.ServiceTitle).Distinct().Count();
        }

        public Dictionary<string, int> GetBookingsByStatus()
        {
            return _db.Bookings
                .GroupBy(b => b.Status)
                .ToDictionary(g => g.Key.ToString(), g => g.Count());
        }



        public decimal GetTotalRevenueFromBookings()
        {
            return _db.Bookings
                .Where(b => b.Status == BookingStatus.Completed)
                .Sum(b => b.WorkingTime * b.Provider.PerHourPrice);
        }

        public int GetTotalNumberOfNewUsersThisMonth()
        {
            var startOfMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            return _db.Users.Count(u => u.JoinDate >= startOfMonth);
        }

        public Dictionary<string, int> GetUsersByCity()
        {
            return _db.Users
                .Where(u => !string.IsNullOrEmpty(u.City))
                .GroupBy(u => u.City)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public int GetAverageBookingDuration()
        {
            return (int)_db.Bookings.Average(b => b.WorkingTime);
        }

        public Dictionary<string, int> GetSubscriptionsByPlan()
        {
            return _db.Subscriptions
                .Include(s => s.Plan)
                .GroupBy(s => s.Plan.Title)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public int GetTotalNumberOfExpiredSubscriptions()
        {
            return _db.Subscriptions.Count(s => s.ExpireAt <= DateTime.UtcNow);
        }

    }
}
