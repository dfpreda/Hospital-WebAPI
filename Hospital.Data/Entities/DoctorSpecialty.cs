using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Entities
{
    public class DoctorSpecialty : BaseEntity
    {
        public Guid SpecialtyId { get; set; }
        public Doctor Doctor { get; set; }
        public Specialty Specialty { get; set; }
    }
}
