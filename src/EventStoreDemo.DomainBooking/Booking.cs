using EventStoreDemo.Domain.Booking.Events;
using System;
using System.Collections.Generic;

namespace EventStoreDemo.Domain.Booking
{
    public class Booking : AggregateRoot
    {
        public PaymentStatus PaymentStatus { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public string BookingNumber { get; set; }

        public DateTime BookingDate { get; set; }

        public BookingInfo Info { get; set; }
        public BookingCustomer Customer{ get; set;}

        public IEnumerable<Payment> Payments { get; set; }

        public Cancellation Cancellation { get; set; }
        public void CreateBooking(BookingInfo info, BookingCustomer customer)
        {
            var bookingNumber = Guid.NewGuid().ToString("N");
            BookingNumber = bookingNumber;
            PaymentStatus = PaymentStatus.NoPaymentReceived;
            BookingStatus = BookingStatus.Active;
            BookingDate = DateTime.Now;
            Info = info;
            Customer = customer;
            AddEvent(new BookingCreated
            {
                BookingNumber = bookingNumber,
                BookingDate = DateTime.Now,
                BookingStatus = BookingStatus.Active,
                PaymentStatus = PaymentStatus.NoPaymentReceived,
                Info = info,
                Customer = customer
            });
        }

        public void CancelBooking(string cancelledBy, DateTime cancellationDate)
        {
            this.BookingStatus = BookingStatus.Cancelled;

            // calculate cancellation fee
            var cancellationFee = 100;
            if(Info.PickupTime.Date.Subtract(cancellationDate).Days < 5)
            {
                cancellationFee = 200;
            }

            var cancellation = new Cancellation
            {
                CancellationDate = cancellationDate,
                CancellationFee = cancellationFee
            };
            Cancellation = cancellation;

            // fire event
            AddEvent(new BookingCancelled
            {
                Cancellation = cancellation,
            });
        }

        public void RegisterPayment(int amount, DateTime paymentDate)
        {

        }

    }
}
