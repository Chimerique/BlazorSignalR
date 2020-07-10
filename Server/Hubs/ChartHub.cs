using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Hubs
{
    public class ChartHub : Hub
    {
        public async Task UpdateChart(string data)
        {
            await Clients.All.SendAsync("UpdateChart", data);
        }
    }
}