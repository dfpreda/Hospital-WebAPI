using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Entities
{
    public class Doctor : BaseEntity
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            DoctorSpecialties = new HashSet<DoctorSpecialty>();
        }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Phone { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorSpecialty> DoctorSpecialties { get; set; }
    }
}
