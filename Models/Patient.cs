using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial1.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double IIN { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string Surname { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Address { get; set; }
        [RegularExpression(@"/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/")]
        [Required]
        public string PhoneNumber { get; set; }
    }
}
