using EventStoreDemo.Domain.Car.Events;
using EventStoreDemo.Domain.EventHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.EventHandlers
{
    public class DrivingStoppedEventHandler : DomainEventHandler<DrivingStopped>
    {
    }
}
