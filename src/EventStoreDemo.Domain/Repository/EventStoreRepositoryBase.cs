using EventStore.ClientAPI;
using EventStoreDemo.Domain.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Repository
{
    
    public abstract class EventStoreRepositoryBase<T>
        where T : AggregateRoot
    {
        public abstract IEnumerable<T> GetAll();

        public abstract T GetOne(object key);
        protected IEnumerable<ResolvedEvent> GetEventsFromStream(string stream)
        {
            using (var connection = EventStoreConnection.Create(new Uri(GetEventStoreUrl()), typeof(T).Name))
            {
                connection.ConnectAsync().Wait();
                var events = ReadEventsFromStart(connection, stream);
                connection.Close();
                return events;
            }
        }

        private string GetEventStoreUrl()
        {
            var envVar = Environment.GetEnvironmentVariable("DEMO1_EVENTSTORE_URL");
            if (string.IsNullOrEmpty(envVar))
                return "ConnectTo=tcp://admin:changeit@localhost:1113";
            return envVar;
        }

        //private static void PrintResolvedEvent(ResolvedEvent e)
        //{
        //    Console.WriteLine($"*** Event {e.OriginalEventNumber} ***");
        //    Console.WriteLine($"Type: {e.OriginalEvent.EventType} ***");
        //    Console.WriteLine($"Created: {e.OriginalEvent.Created}");
        //    Console.WriteLine("Data: ");
        //    Console.WriteLine(EventDataToString(e.OriginalEvent));
        //    Console.WriteLine();
        //}

        protected string EventDataToString(RecordedEvent e)
        {
            var data = e.Data;
            return Encoding.UTF8.GetString(data);
        }

        protected T1 EventDataTo<T1>(RecordedEvent e)
            where T1 : Event
        {
            return JsonConvert.DeserializeObject<T1>(EventDataToString(e));
        }

        private static List<ResolvedEvent> ReadEventsFromStart(IEventStoreConnection connection, string stream)
        {
            var streamEvents = new List<ResolvedEvent>();

            StreamEventsSlice currentSlice;
            var nextSliceStart = StreamPosition.Start;
            do
            {
                currentSlice =
                connection.ReadStreamEventsForwardAsync(stream, nextSliceStart,
                                                              200, false)
                                                              .Result;

                nextSliceStart = (int)currentSlice.NextEventNumber;

                streamEvents.AddRange(currentSlice.Events);
            } while (!currentSlice.IsEndOfStream);
            return streamEvents;
        }

    }
}
