using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Craftify.Domain.Entities;
namespace Craftify.Application.Notifications.Commands.AddNotification
{
    internal class AddNotificationCommandHandler : IRequestHandler<AddNotificationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddNotificationCommandHandler(IUnitOfWork unitOfWork)
        {
             _unitOfWork = unitOfWork;
        }
        public Task<Unit> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Notification()
            {
                Content = request.Content,
                IsRead = request.IsRead,
                SenderId = request.SenderId,
                Subject = request.Subject,
                Timestamp = request.Timestamp,
                Type = request.Type,
                UserId = request.UserId,
            };

            _unitOfWork.Notification.Add(notification);
            _unitOfWork.Save();

            return Unit.Task;
        }
    }
}
