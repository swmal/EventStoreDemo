using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.Events
{
    public class BookingCancelled : Event
    {
        public Cancellation Cancellation { get; set; }

        public override string Stream => Streams.Booking;
    }
}
