using EventStore.ClientAPI;
using EventStoreDemo.Domain.EventHandlers;
using EventStoreDemo.Domain.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain
{
    public class DomainEventHandler<T> : IDomainEventHandler
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

        private string GetEventStoreUrl()
        {
            var envVar = Environment.GetEnvironmentVariable("DEMO1_EVENTSTORE_URL");
            if (string.IsNullOrEmpty(envVar))
                return "tcp://admin:changeit@localhost:1113";
            return envVar;
        }

        public void HandleEvent(Event evt)
        {
            var e = CastEvent(evt);
            var connection = EventStoreConnection.Create(new Uri(GetEventStoreUrl()), "DomainEventHandler");
            connection.ConnectAsync().Wait();
            var eventData = new EventData(e.Id, typeof(T).Name, true, EventToJsonBytes(e), null);
            connection.AppendToStreamAsync(e.Stream, ExpectedVersion.Any, eventData).Wait();
            connection.Close();
            connection.Dispose();
        }
    }
}
