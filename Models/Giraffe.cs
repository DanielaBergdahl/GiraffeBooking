using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiraffeBooking.Models
{
    public class Giraffe
    {
        public Guid Id { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Name { get; set; }
        public int DegreeOfTameness { get; set; }
        public int Size { get; set; }
        public decimal Price { get; set; }
    }
}
