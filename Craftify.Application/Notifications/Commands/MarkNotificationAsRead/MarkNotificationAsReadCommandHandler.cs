using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Craftify.Application.Notifications.Commands.MarkNotificationAsRead
{
    public class MarkNotificationAsReadCommandHandler : IRequestHandler<MarkNotificationAsReadCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarkNotificationAsReadCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(MarkNotificationAsReadCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Notification.MarkAsReadAsync(request.NotificationId);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
