using EventStoreDemo.Domain.Car.EventHandlers;
using EventStoreDemo.Domain.Car.Events;
using EventStoreDemo.Domain.Car.EventsRental;
using EventStoreDemo.Domain.CarRental.EventHandlers;
using EventStoreDemo.Domain.CarRental.Events;
using EventStoreDemo.Domain.EventHandlers;
using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain
{
    public static class DomainEventHandlers
    {
        private static readonly Dictionary<Type, IDomainEventHandler> _eventHandlers = new Dictionary<Type, IDomainEventHandler>()
        {
            // Car rental
            { typeof(CarPickedUp), new CarPickedUpEventHandler() },
            { typeof(CarReturned), new CarReturnedEventHandler() },
            { typeof(CarSold), new CarSoldEventHandler() },
            { typeof(CarAquired), new CarAquiredEventHandler() },
            { typeof(CarRentalEstablished), new CarRentalEstablishedEventHandler() },
            { typeof(CarServiceNeedIdentified), new CarServiceNeededEventHandler() },
            // Car
            { typeof(DrivingStarted), new DrivingStartedEventHandler() },
            { typeof(DrivingStopped), new DrivingStoppedEventHandler() },
            { typeof(OwnerChanged), new OwnerChangedEventHandler() },
            
            

        };

        public static void Publish(Event e)
        {
            var type = e.GetType();
            if(_eventHandlers.ContainsKey(type))
            {
                 _eventHandlers[type].HandleEvent(e);
            }
        }
    }
}
