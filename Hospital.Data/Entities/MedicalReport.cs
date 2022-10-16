using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Data.Entities
{
    public class MedicalReport : BaseEntity
    {
        public string InvestigationsMade { get; set; }
        public string Findings { get; set; }
        public string Diagnosis { get; set; }
        public string Treatment { get; set; }
        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
