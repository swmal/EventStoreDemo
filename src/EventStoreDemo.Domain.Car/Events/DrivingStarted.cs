using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.Events
{
    public class DrivingStarted : Event
    {
        public string Registration { get; set; }

        public Driver Driver { get; set; }

        public DateTime DrivingStartedAt { get; set; }

        public override string Stream => Streams.Car;
    }
}
