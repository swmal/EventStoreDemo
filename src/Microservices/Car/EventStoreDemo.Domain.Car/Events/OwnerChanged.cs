using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.Events
{
    public class OwnerChanged : Event
    {
        public string Registration { get; set; }

        public string PreviousOwner { get; set; }

        public string NewOwner { get; set; }

        public DateTime ChangeDate { get; set; }
        public override string Stream => Streams.Car;
    }
}
