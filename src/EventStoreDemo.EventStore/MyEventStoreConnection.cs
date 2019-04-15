using System;
using EventStore.ClientAPI;

namespace EventStoreDemo.EventStore
{
    public class MyEventStoreConnection : IDisposable
    {
        public MyEventStoreConnection()
        {
            _connection = EventStoreConnection.Create(new Uri("tcp://admin:changeit@localhost:1113"), "InputFromFileConsoleApp");
            _connection.ConnectAsync().Wait();
        }

        private readonly IEventStoreConnection _connection;

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
