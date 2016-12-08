using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DoubleBooking.Domain.Model
{
    public class BookingsViewModel
    {
        public string Email { get; set; }
        public DateTime DateBooking { get; set; }
        public int SelectedLocalAuthorities { get; set; }
        public IEnumerable<SelectListItem> LocalAuthorities { get; set; }
    }
}
