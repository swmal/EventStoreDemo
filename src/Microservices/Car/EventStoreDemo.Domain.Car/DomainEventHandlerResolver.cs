using System;
using System.Collections.Generic;
using System.Text;
using EventStoreDemo.Domain.Car.EventHandlers;
using EventStoreDemo.Domain.Car.Events;
using EventStoreDemo.Domain.EventHandlers;

namespace EventStoreDemo.Domain.Car
{
    public class DomainEventHandlerResolver : IDomainEventHandlerResolver
    {
        private static Dictionary<Type, IDomainEventHandler> _handlers => new Dictionary<Type, IDomainEventHandler>()
        {
            { typeof(DrivingStarted), new DrivingStartedEventHandler() },
            { typeof(DrivingStopped), new DrivingStoppedEventHandler() },
            { typeof(CarAquired), new CarAquiredEventHandler() }
        };

        public IDomainEventHandler ResolveHandler(Type type)
        {
            if(!_handlers.ContainsKey(type))
            {
                throw new InvalidOperationException("No such event handler present: " + type.Name);
            }
            return _handlers[type];
        }
    }
}
