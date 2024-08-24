namespace Craftify.Application.Common.Interfaces.Persistence.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository User {  get; }

        IPlanRepository Plan { get; }

        IChatRepository Chat { get; }


        IWorkerRepository Worker { get; }

        IBookingRepository Booking { get; }

        IReviewRatingRepository ReviewRating { get; }

        INotificationRepository Notification { get; }

        IReportRepository Report { get; }

        Task Save();
    }
}
