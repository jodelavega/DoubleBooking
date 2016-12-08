using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleBooking.Domain.Entities
{
    public class Booking: BaseClass
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateBooking { get; set; }

        
        public int ClerkId { get; set; }

        
        public int LocalAuthoritiesId { get; set; }

        [ForeignKey("ClerkId")]
        public virtual Clerk Clerk { get; set; }

        [ForeignKey("LocalAuthoritiesId")]
        public virtual LocalAuthorities LocalAuthorities { get; set; }
    }
}
