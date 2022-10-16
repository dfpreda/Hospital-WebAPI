using Hospital.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Repositories.Contracts
{
    public interface IDoctorsRepository : IBaseRepository<Doctor>
    {
        Task<Doctor> RegisterAsync(Doctor entity, byte[] passwordHash, byte[] passwordSalt);
    }
}
