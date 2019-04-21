using EventStoreDemo.Domain.Car.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.EventHandlers
{
    public class CarAquiredEventHandler : DomainEventHandler<CarAquired>
    {
    }
}
