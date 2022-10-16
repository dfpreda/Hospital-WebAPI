using Hospital.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Dtos.PostDtos
{
    public class DoctorPostDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public IEnumerable<DoctorSpecialtyPostDto> DoctorSpecialties { get; set; }
    }
}
