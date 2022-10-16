using Hospital.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Repositories.Contracts
{
    public interface IPatientsRepository : IBaseRepository<Patient>
    {
        Task<Patient> RegisterAsync(Patient entity, byte[] passwordHash, byte[] passwordSalt);
    }
}
