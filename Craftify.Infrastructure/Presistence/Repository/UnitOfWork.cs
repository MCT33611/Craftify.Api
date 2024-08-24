﻿using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Infrastructure.Persistence.Repository;
using Craftify.Infrastructure.Presistence.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Craftify.Infrastructure.Presistence.Repository
{
    public class UnitOfWork(
        CraftifyDbContext _db,
        IPasswordHasher<object> _passwordHasher
        ) : IUnitOfWork
    {

        public IUserRepository User { get; } = new UserRepository(_db,_passwordHasher);



        public IPlanRepository Plan => new PlanRepository(_db);

        public IChatRepository Chat => new ChatRepository(_db);


        public IWorkerRepository Worker => new WorkerRepository(_db);

        public IBookingRepository Booking => new BookingRepository(_db);

        public IReviewRatingRepository ReviewRating => new ReviewRatingRepository(_db);

        public INotificationRepository Notification => new NotificationRepository(_db);

        public IReportRepository Report => new ReportRepository(_db);

        public async Task Save()
        {
           await _db.SaveChangesAsync();
        }
    }
}
