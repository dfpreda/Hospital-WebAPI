using Hospital.Data.Entities;
using Hospital.Repositories.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Repositories.Implementations
{
    public class DoctorSpecialtiesRepository : BaseRepository<DoctorSpecialty>, IDoctorSpecialtiesRepository
    {
        public DoctorSpecialtiesRepository(HospitalDbContext context) : base(context)
        {

        }
    }
}
