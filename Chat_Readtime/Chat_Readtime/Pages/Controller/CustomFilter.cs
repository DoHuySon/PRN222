using Microsoft.AspNetCore.SignalR;

namespace Chat_Readtime.Pages.controller
{
    public class CustomFilter : IHubFilter
    {
        public async ValueTask<object> InvokeMethodAsync(
            HubInvocationContext invocationContext, Func<HubInvocationContext, ValueTask<object>> next)
        {
            Console.WriteLine($"Calling hub method'{invocationContext.HubMethodName}'");
            try
            {
                return await next(invocationContext);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception calling'{invocationContext.HubMethodName}' : {ex} ");
                throw;
            }
        }
        public Task OnConnectAsync(HubLifetimeContext context, Func<HubLifetimeContext,Task> next)
        {
            return next(context);
        }
        //public Task OnDisconnectAsync(
        //    HubLifetimeContext context,Exception exception, Func<HubLifetimeContext,Exception,Task> next)
        //{

        //}
    }
}
