using System;
using System.Collections.Generic;
using System.Text;
using EventStoreDemo.Domain.EventHandlers;
using EventStoreDemo.Domain.Payment.EventHandlers;
using EventStoreDemo.Domain.Payment.Events;

namespace EventStoreDemo.Domain.Payment
{
    public class DomainEventHandlerResolver : IDomainEventHandlerResolver
    {
        private static Dictionary<Type, IDomainEventHandler> _handlers => new Dictionary<Type, IDomainEventHandler>()
        {
            { typeof(PaymentPerformed), new PaymentPerformedEventHandler() }
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
