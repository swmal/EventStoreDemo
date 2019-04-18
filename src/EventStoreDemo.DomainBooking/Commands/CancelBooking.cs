using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.Commands
{
    public class CancelBooking : Command<Booking>
    {
        public string BookingNumber { get; set; }

        public string CancelledBy { get; set; }
    }
}
