using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Common.Interfaces.Persistence.IRepository
{
    public interface IReportRepository
    {
        int GetTotalNumberOfUsers();
        int GetTotalNumberOfActiveUsers();
        int GetTotalNumberOfBlockedUsers();
        int GetTotalNumberOfWorkers();
        int GetTotalNumberOfApprovedWorkers();
        int GetTotalNumberOfUnapprovedWorkers();
        int GetTotalNumberOfBookings();
        int GetTotalNumberOfPendingBookings();
        int GetTotalNumberOfCompletedBookings();
        int GetTotalNumberOfCancelledBookings();
        int GetTotalNumberOfRejectedBookings();
        int GetTotalNumberOfAcceptedBookings();
        int GetTotalNumberOfSubscriptions();
        int GetTotalNumberOfActiveSubscriptions();
        int TotalRevenueBySubscriptions();
        int TotalRevenueByActiveSubscriptions();
        decimal GetAverageWorkerHourlyRate();
        int GetTotalNumberOfServiceCategories();
        Dictionary<string, int> GetBookingsByStatus();
        decimal GetTotalRevenueFromBookings();
        int GetTotalNumberOfNewUsersThisMonth();
        Dictionary<string, int> GetUsersByCity();
        int GetAverageBookingDuration();
        Dictionary<string, int> GetSubscriptionsByPlan();
        int GetTotalNumberOfExpiredSubscriptions();
    }
}
