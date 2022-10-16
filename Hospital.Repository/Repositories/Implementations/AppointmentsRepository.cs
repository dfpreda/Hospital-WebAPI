using Hospital.Data.Entities;
using Hospital.Repositories.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Repositories.Implementations
{
    public class AppointmentsRepository : BaseRepository<Appointment>, IAppointmentsRepository
    {
        public AppointmentsRepository(HospitalDbContext context) : base(context)
        {

        }
    }
}
