using Hospital.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Dtos.GetDtos
{
    public class SpecialtyGetDto : SpecialtyPostDto
    {
        public Guid Id { get; set; }
    }
}
