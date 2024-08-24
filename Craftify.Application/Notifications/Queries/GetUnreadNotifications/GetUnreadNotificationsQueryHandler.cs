using Craftify.Application.Common.Interfaces.Persistence.IRepository;
using Craftify.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craftify.Application.Notifications.Queries.GetUnreadNotifications
{
    public class GetUnreadNotificationsQueryHandler : IRequestHandler<GetUnreadNotificationsQuery, List<Notification>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUnreadNotificationsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Notification>> Handle(GetUnreadNotificationsQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Notification.GetUnreadNotificationsAsync(request.UserId);
        }
    }
}
