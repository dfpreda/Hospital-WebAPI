using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Entities
{
    public class Specialty : BaseEntity
    {
        public Specialty()
        {
            DoctorSpecialties = new HashSet<DoctorSpecialty>();
        }
        public string Name { get; set; }
        public string AgeRange { get; set; }
        public bool Surgical { get; set; }
        public bool Therapeutic { get; set; }
        public Guid? MainSpecialtyId { get; set; }
        public Specialty MainSpecialty { get; set; }
        public ICollection<DoctorSpecialty> DoctorSpecialties { get; set; }
    }
}
