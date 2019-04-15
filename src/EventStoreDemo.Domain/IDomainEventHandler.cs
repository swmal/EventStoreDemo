using System;
using System.Collections.Generic;
using System.Text;
using EventStoreDemo.Domain.Events;

namespace EventStoreDemo.Domain.EventHandlers
{
    public interface IDomainEventHandler
    {
        void HandleEvent(Event e);
    }
}
