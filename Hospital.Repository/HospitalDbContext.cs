using Hospital.Data.Abstractions;
using Hospital.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) {}

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne<MedicalReport>(a => a.MedicalReport)
                .WithOne(m => m.Appointment)
                .HasForeignKey<MedicalReport>(m => m.AppointmentId)
                .HasConstraintName("FK_Appointment_MedicalReport");

            modelBuilder.Entity<Doctor>()
                .HasMany<Appointment>(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .HasConstraintName("FK_Doctor_Appointments");

            modelBuilder.Entity<Patient>()
                .HasMany<Appointment>(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .HasConstraintName("FK_Patient_Appointments");

            modelBuilder.Entity<DoctorSpecialty>().HasKey(ds => new { ds.Id, ds.SpecialtyId });

            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne<Doctor>(ds => ds.Doctor)
                .WithMany(d => d.DoctorSpecialties)
                .HasForeignKey(ds => ds.Id)
                .HasConstraintName("FK_Doctor_DoctorSpecialties");

            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne<Specialty>(ds => ds.Specialty)
                .WithMany(s => s.DoctorSpecialties)
                .HasForeignKey(ds => ds.SpecialtyId)
                .HasConstraintName("FK_Specialty_Doctorspecialties");
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddAuditInfo()
        {
            var entities = ChangeTracker.Entries<IBaseEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            var utcNow = DateTimeOffset.UtcNow;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = utcNow;
                }

                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedAt = utcNow;
                }
            }
        }
    }
}
