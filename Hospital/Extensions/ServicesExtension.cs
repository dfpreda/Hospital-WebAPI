using Hospital.BackgroundWorkers.Services.Contracts;
using Hospital.BackgroundWorkers.Services.Implementations;
using Hospital.BackgroundWorkers.Workers;
using Hospital.Dtos.Profiles;
using Hospital.Repositories.Repositories.Contracts;
using Hospital.Repositories.Repositories.Implementations;
using Hospital.Repositories.UnitofWork;
using Hospital.Services.DataServices.Contracts;
using Hospital.Services.DataServices.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital.Extensions
{
    public static class ServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DummyProfile).Assembly);

            services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
            services.AddScoped<IDoctorsRepository, DoctorsRepository>();
            services.AddScoped<IMedicalReportsRepository, MedicalReportsRepository>();
            services.AddScoped<IPatientsRepository, PatientsRepository>();
            services.AddScoped<ISpecialtiesRepository, SpecialtiesRepository>();
            services.AddScoped<IDoctorSpecialtiesRepository, DoctorSpecialtiesRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAppointmentsService, AppointmentsService>();
            services.AddScoped<IDoctorsService, DoctorsService>();
            services.AddScoped<IMedicalReportsService, MedicalReportsService>();
            services.AddScoped<IPatientsService, PatientsService>();
            services.AddScoped<ISpecialtiesService, SpecialtiesService>();
            services.AddScoped<IMedicalReportsExportService, MedicalReportsExportService>();
            services.AddScoped<IExcelExportService, ExcelExportService>();
            services.AddHostedService<ExcelExportBackgroundWorker>();
        }
    }
}
