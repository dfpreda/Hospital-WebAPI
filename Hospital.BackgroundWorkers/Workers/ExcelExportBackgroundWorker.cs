using Hospital.BackgroundWorkers.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital.BackgroundWorkers.Workers
{
    public class ExcelExportBackgroundWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ExcelExportBackgroundWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                using (var scope = _serviceProvider.CreateScope())
                {

                    using (var service = scope.ServiceProvider.GetService<IExcelExportService>())
                    {
                        await service.Start();
                    }

                }
                await Task.Delay(5 * 1000);
            }
        }
    }
}
