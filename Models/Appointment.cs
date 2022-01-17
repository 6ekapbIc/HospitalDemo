using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial1.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int DoctorId { get; set; }
        [Required]
        [MinLength(3)]
        public string Diagnose { get; set; }
        [Required]
        [MinLength(3)]
        public string Complaints { get; set; }
        [DisplayName("Date of visit")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfVisit { get; set; }
        public int PatientId { get; set; }

        [NotMapped]
        [Required]
        [DisplayName("Doctor's name")]
        public string DoctorName { get; set; }
        [NotMapped]
        [DisplayName("Patient's name")]
        [Required]
        public string PatientName { get; set; }
    }
}
