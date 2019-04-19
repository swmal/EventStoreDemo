using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking
{
    public class BookingCustomer
    {
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
