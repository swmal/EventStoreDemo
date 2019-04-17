using System;
using System.Collections.Generic;
using System.Text;
using EventStoreDemo.Domain.CarRental.EventHandlers;
using EventStoreDemo.Domain.CarRental.Events;
using EventStoreDemo.Domain.EventHandlers;

namespace EventStoreDemo.Domain.CarRental
{
    public class DomainEventHandlerResolver : IDomainEventHandlerResolver
    {
        private static Dictionary<Type, IDomainEventHandler> _handlers => new Dictionary<Type, IDomainEventHandler>()
        {
            { typeof(CarPickedUp), new CarPickedUpEventHandler() },
            { typeof(CarReturned), new CarReturnedEventHandler() },
            { typeof(CarSold), new CarSoldEventHandler() },
            { typeof(CarAquired), new CarAquiredEventHandler() },
            { typeof(CarRentalEstablished), new CarRentalEstablishedEventHandler() },
            { typeof(CarServiceNeedIdentified), new CarServiceNeededEventHandler() }
        };

        public IDomainEventHandler ResolveHandler(Type type)
        {
            if (!_handlers.ContainsKey(type))
            {
                throw new InvalidOperationException("No such event handler present: " + type.Name);
            }
            return _handlers[type];
        }
    }
}
