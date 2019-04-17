using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Events
{
    public class CarRentalEstablished : Event
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime EstablishedDate { get; set; }

        public override string Stream => Streams.CarRental;
    }
}
