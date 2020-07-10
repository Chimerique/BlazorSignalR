using BlazorApp1.Server.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorApp1.Server
{
    public class UpdateChartService : BackgroundService
    {
        readonly IHubContext<ChartHub> m_hubContext;
        static double m_randomValue = 1000;
        static Random m_random;

        public UpdateChartService(IHubContext<ChartHub> hubContext, ILogger<UpdateChartService> logger)
        {
            m_hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //basic random value
                if (m_random == null)
                    m_random = new Random(5);

                var randomVal = m_random.NextDouble() * 10;//No negative value possible
                var negpos = m_random.Next(-1, 2);
                m_randomValue += (randomVal * negpos);//random negative or positive
                var data = $"{{\"time\": {DateTimeOffset.Now.ToUnixTimeSeconds()}, \"value\": {m_randomValue.ToString().Replace(",",".")} }}";
                await m_hubContext.Clients.All.SendAsync("UpdateChart", data);

                await Task.Delay(2000);
            }
        }
    }
}