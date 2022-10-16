using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Dtos.PostDtos
{
    public class SpecialtyPostDto
    {
        public string Name { get; set; }
        public string AgeRange { get; set; }
        public bool Surgical { get; set; }
        public bool Therapeutic { get; set; }
        public Guid? MainSpecialtyId { get; set; }
    }
}
