using EventStoreDemo.Domain.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStoreDemo.Api.Booking.Models
{
    public class BookingModel
    {
        public string BookingNumber { get; set; }

        public DateTime BookingDate { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
        public BookingInfo Info { get; set; }

        public BookingCustomer Customer { get; set; }
    }
}
