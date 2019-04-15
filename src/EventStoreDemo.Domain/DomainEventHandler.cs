using EventStore.ClientAPI;
using EventStoreDemo.Domain.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain
{
    public class DomainEventHandler<T>
        where T : Event
    {
        private T CastEvent(Event e)
        {
            return e as T;
        }

        private byte[] EventToJsonBytes(T e)
        {
            var s = JsonConvert.SerializeObject(e);
            return Encoding.UTF8.GetBytes(s);
        }

        public void HandleEvent(Event evt)
        {
            var e = CastEvent(evt);
            var connection = EventStoreConnection.Create(new Uri("tcp://admin:changeit@localhost:1113"), "InputFromFileConsoleApp");
            connection.ConnectAsync().Wait();
            var eventData = new EventData(e.Id, typeof(T).Name, true, EventToJsonBytes(e), null);
            connection.AppendToStreamAsync(e.Stream, ExpectedVersion.Any, eventData).Wait();
            connection.Close();
            connection.Dispose();
        }
    }
}
