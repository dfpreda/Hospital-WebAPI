using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Dtos.PostDtos
{
    public class LoginPostDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
