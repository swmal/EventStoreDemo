using System;
using System.Collections.Generic;
using System.Text;
using EventStoreDemo.Domain.Booking.EventHandlers;
using EventStoreDemo.Domain.Booking.Events;
using EventStoreDemo.Domain.EventHandlers;

namespace EventStoreDemo.Domain.Booking
{
    public class DomainEventHandlerResolver : IDomainEventHandlerResolver
    {
        private static Dictionary<Type, IDomainEventHandler> _handlers => new Dictionary<Type, IDomainEventHandler>()
        {
            { typeof(BookingCreated), new BookingCreatedEventHandler() },
            { typeof(BookingCancelled), new BookingCancelledEventHandler() },
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
