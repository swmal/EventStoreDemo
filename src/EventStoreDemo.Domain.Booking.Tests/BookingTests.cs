using EventStoreDemo.Domain.Booking.CommandHandlers;
using EventStoreDemo.Domain.Booking.Commands;
using EventStoreDemo.Domain.Booking.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EventStoreDemo.Domain.Booking.Tests
{
    [TestClass]
    public class BookingTests
    {
        [TestMethod]
        public void AddBooking()
        {
            var command = new CreateBooking
            {
                Info = new BookingInfo
                {
                    CarRegistration = "ABC 123",
                    CarRentalCode = "MA",
                    PickupTime = DateTime.Now,
                    ReturnTime = DateTime.Now.AddDays(2)
                },
            Customer = new BookingCustomer
            {
                Name = "Mats Alm",
                Address = new Address
                {
                    Street = "Storgatan 1",
                    ZipCode = "12345",
                    City = "Stockholm"
                }
            }
            };
            var handler = new CreateBookingCommandHandler(command);
            handler.Execute();
        }

        [TestMethod]
        public void CancelBooking()
        {
            var bono = "51623d5d3afe4716ae2de0826f870798";
            var repo = new BookingRepository();
            var booking = repo.GetOne(bono);

            var command = new CancelBooking
            {
                BookingNumber = bono,
                CancelledBy = "Mats Alm"
            };

            var handler = new CancelBookingCommandHandler(command, booking);
            handler.Execute();
        }
    }
}
