using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.Repository
{
    public class MongoBooking
    {
        [BsonId]
        public long Id { get; set; }

        public Booking Booking { get; set; }
    }
}
