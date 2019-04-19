using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventStoreDemo.Domain.Booking.Repository
{
    public class BookingRepository
    {
        public void InsertOrUpdate(Booking booking)
        {
            var db = MongoDb.GetBookingDomainDb();
            var bookingColl = db.GetCollection<MongoBooking>("bookings");
            var filter = Builders<MongoBooking>.Filter.Eq(x => x.Booking.BookingNumber, booking.BookingNumber);
            var existingBooking = bookingColl.FindAsync(filter).Result.FirstOrDefault();
            if(existingBooking != null)
            {
                bookingColl.DeleteOne(filter);
            }
            var mongoBooking = new MongoBooking { Booking = booking };
            bookingColl.InsertOne(mongoBooking);
        }

        public Booking GetOne(string bookingNumber)
        {
            var db = MongoDb.GetBookingDomainDb();
            var bookingColl = db.GetCollection<MongoBooking>("bookings");
            var filter = Builders<MongoBooking>.Filter.Eq(x => x.Booking.BookingNumber, bookingNumber);
            var existingBooking = bookingColl.FindAsync(filter).Result.FirstOrDefault();
            return existingBooking.Booking;
        }

        public IEnumerable<Booking> GetAll()
        {
            var db = MongoDb.GetBookingDomainDb();
            var bookingColl = db.GetCollection<MongoBooking>("bookings");
            var result = bookingColl.FindAsync(Builders<MongoBooking>.Filter.Empty).Result.ToList();
            foreach (var mb in result)
                yield return mb.Booking;

        }
    }
}
