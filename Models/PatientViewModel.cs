using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial1.Models
{
    public class PatientViewModel
    {
        public Patient patient { get; set; }
        public List<Patient> patients { get; set; }
    }
}
