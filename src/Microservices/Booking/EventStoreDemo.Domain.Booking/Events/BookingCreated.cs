using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.Events
{
    public class BookingCreated : Event
    {
        public string BookingNumber { get; set; }

        public DateTime BookingDate { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public BookingInfo Info { get; set; }

        public BookingCustomer Customer { get; set; }

        public override string Stream => Streams.Booking;
    }
}
