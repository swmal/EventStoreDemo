using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStoreDemo.Api.Booking.Models
{
    public class BookingRowModel
    {
        public string BookingNumber { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime PickupDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public string CustomerName { get; set; }
    }
}
