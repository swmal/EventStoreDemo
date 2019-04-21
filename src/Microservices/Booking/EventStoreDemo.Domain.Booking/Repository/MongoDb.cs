using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Core.Connections;

namespace EventStoreDemo.Domain.Booking.Repository
{
    public static class MongoDb
    {
        public static IMongoDatabase GetBookingDomainDb()
        {
            var connectionString = "mongodb://localhost:27017";
            var envUrl = Environment.GetEnvironmentVariable("DEMO1_MONGODB_URL");
            if (!string.IsNullOrEmpty(envUrl))
            {
                connectionString = envUrl;
            }
            var client = new MongoClient(connectionString);
            return client.GetDatabase("bookingdomain");
        }
           
    }
}
