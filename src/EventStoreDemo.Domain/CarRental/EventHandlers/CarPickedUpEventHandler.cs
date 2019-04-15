using System;
using System.Collections.Generic;
using System.Text;
using EventStoreDemo.Domain.CarRental.Events;
using EventStoreDemo.Domain.EventHandlers;
using EventStoreDemo.Domain.Events;

namespace EventStoreDemo.Domain.CarRental.EventHandlers
{
    public class CarPickedUpEventHandler : DomainEventHandler<CarPickedUp>, IDomainEventHandler
    {

    }
}
