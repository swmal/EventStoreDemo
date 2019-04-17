using EventStoreDemo.Domain.EventHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain
{
    public interface IDomainEventHandlerResolver
    {
        IDomainEventHandler ResolveHandler(Type type);
    }
}
