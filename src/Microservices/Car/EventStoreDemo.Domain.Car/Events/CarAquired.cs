using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.Events
{
    public class CarAquired : Event
    {
        public string Registration { get; set; }
        public string Model { get; set; }

        public int Milage { get; set; }

        public DateTime RegistrationDate { get; set; }
        public override string Stream => Streams.Car;
    }
}
