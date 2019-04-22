using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain
{
    public abstract class EventStreamProvider
    {
        public abstract void Publish(Guid eventId, string stream, string eventName, byte[] data);
    }
}
