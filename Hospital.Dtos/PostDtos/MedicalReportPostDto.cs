 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Dtos.PostDtos
{
    public class MedicalReportPostDto
    {
        public string InvestigationsMade { get; set; }
        public string Findings { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public Guid AppointmentId { get; set; }
    }
}
