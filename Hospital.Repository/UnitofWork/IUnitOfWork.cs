using Hospital.Repositories.Repositories.Contracts;
using System;
using System.Threading.Tasks;

namespace Hospital.Repositories.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentsRepository AppointmentsRepository { get; }
        IDoctorsRepository DoctorsRepository { get; }
        IMedicalReportsRepository MedicalReportsRepository { get; }
        IPatientsRepository PatientsRepository { get; }
        ISpecialtiesRepository SpecialtiesRepository { get; }
        IDoctorSpecialtiesRepository DoctorSpecialtiesRepository { get; }

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollBackTransactionAsync();
        Task SaveAsync();
    }
}