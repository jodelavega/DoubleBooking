using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleBooking.Domain.Model
{
    public class BookingReportViewModel
    {
        public string LocalAuthoritieName { get; set; }
        public int DoubleBooked { get; set; }

    }
}
