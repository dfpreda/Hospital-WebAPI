using Hospital.Data.Entities;
using Hospital.Repositories.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Repositories.Implementations
{
    public class PatientsRepository : BaseRepository<Patient>, IPatientsRepository
    {
        public PatientsRepository(HospitalDbContext context) : base(context)
        {
            
        }

        public async Task<Patient> RegisterAsync(Patient entity, byte[] passwordHash, byte[] passwordSalt)
        {
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;

            var result = await _dbSet.AddAsync(entity);

            return result.Entity;
        }
    }
}
