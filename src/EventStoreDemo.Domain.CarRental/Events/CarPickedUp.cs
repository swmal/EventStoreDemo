using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Events
{
    public class CarPickedUp : Event
    {
        public string Registration { get; set; }

        public int Milage { get; set; }

        public Driver Driver { get; set; }

        public DateTime PickedUpAt { get; set; }

        public override string Stream => Streams.CarRental;
    }
}
