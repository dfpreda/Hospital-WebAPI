using Hospital.Data.Entities;
using Hospital.Repositories.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Repositories.Implementations
{
    public class SpecialtiesRepository : BaseRepository<Specialty>, ISpecialtiesRepository
    {
        public SpecialtiesRepository(HospitalDbContext context) : base(context)
        {

        }
    }
}
