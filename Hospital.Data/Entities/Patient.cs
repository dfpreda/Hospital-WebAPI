using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Entities
{
    public class Patient : BaseEntity
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string MedicalHistory { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
