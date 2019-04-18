using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.Commands
{
    public class CreateBooking : Command<Booking>
    {
        public BookingInfo Info { get; set; }

        public BookingCustomer Customer{ get;set;}
    }
}
