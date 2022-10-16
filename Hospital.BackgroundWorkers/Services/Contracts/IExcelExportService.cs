using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital.BackgroundWorkers.Services.Contracts
{
    public interface IExcelExportService : IDisposable
    {
        Task Start();
    }
}