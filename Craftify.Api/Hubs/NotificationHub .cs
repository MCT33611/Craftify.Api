using Craftify.Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace Craftify.Api.Hubs
{
    public class NotificationHub : Hub
    {

        public async Task JoinUserGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId,userId);
        }
    }
}
