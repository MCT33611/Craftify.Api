using Craftify.Application.Notifications.Commands.MarkNotificationAsRead;
using Craftify.Application.Notifications.Queries.GetUnreadNotifications;
using Craftify.Application.Notifications.Queries.SendEmail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Craftify.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ApiController
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("unread/{userId}")]
        public async Task<IActionResult> GetUnreadNotifications(string userId)
        {
            var query = new GetUnreadNotificationsQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result.ToList());
        }

        [HttpPost("markAsRead/{notificationId}")]
        public async Task<IActionResult> MarkAsRead(int notificationId)
        {
            var command = new MarkNotificationAsReadCommand(notificationId);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("email/send")]
        public async Task<IActionResult> SendEmail(SendEmailQuery query)
        {
            var result = await _mediator.Send(query);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Failed to send email");
        }


    }
}
