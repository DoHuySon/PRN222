using Microsoft.AspNetCore.SignalR;

namespace Project2
{
    public class MovieHub : Hub
    {
        public async Task NotifyMovieDeleted(int movieId)
        {
            await Clients.All.SendAsync("RefreshPage", movieId);
        }
    }
}
