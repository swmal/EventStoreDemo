using EventStoreDemo.Domain.Car.EventsRental;
using EventStoreDemo.Domain.EventHandlers;
using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.EventHandlers
{
    public class CarRentalEstablishedEventHandler : DomainEventHandler<CarRentalEstablished>, IDomainEventHandler
    {

    }
}
