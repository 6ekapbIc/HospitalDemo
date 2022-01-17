using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial1.Models
{
    public class AppointmentViewModel
    {
        public Appointment appointment { get; set; }
        public List<Appointment> appointments { get; set; }
        public SelectList doctors { get; set; }
        public SelectList patients { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public string Diagnose { get; set; }
        [Required]
        public string Complaints { get; set; }
        [DisplayName("Date of visit")]
        [Required]
        public DateTime DateOfVisit { get; set; }
    }
}
