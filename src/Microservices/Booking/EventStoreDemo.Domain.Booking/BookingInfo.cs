using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking
{
    public class BookingInfo
    {
        public string CarRentalCode { get; set; }

        public string CarRegistration { get; set; }

        public DateTime PickupTime { get; set; }

        public DateTime ReturnTime { get; set; }
    }
}
