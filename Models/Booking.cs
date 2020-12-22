using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GiraffeBooking.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public string GiraffeName { get; set; }
        public Guid GiraffeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookedDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string UserName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
