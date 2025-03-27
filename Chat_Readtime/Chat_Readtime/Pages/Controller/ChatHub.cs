using Microsoft.AspNetCore.SignalR;

namespace Chat_Readtime.Pages.controller
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public Task SendMessageToCalle(string user, string message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }
        public Task SendMessageToGroup(string user, string message)
        {
            return Clients.Group("SignalR Users").SendAsync("ReceiveMessage", user, message);
        }
        [HubMethodName("SendMessageToUser")]
        public Task DirecMessage(string user, string message)
        {
            return Clients.User(user).SendAsync("ReceiveMessage", user, message);
        }
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignlR Users");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
