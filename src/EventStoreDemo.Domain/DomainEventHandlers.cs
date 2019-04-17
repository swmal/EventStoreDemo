
using EventStoreDemo.Domain.EventHandlers;
using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain
{
    public class DomainEventHandlers
    {
        //private static readonly Dictionary<Type, IDomainEventHandler> _eventHandlers = new Dictionary<Type, IDomainEventHandler>()
        //{
        //    // Car rental
        //    { typeof(CarPickedUp), new CarPickedUpEventHandler() },
        //    { typeof(CarReturned), new CarReturnedEventHandler() },
        //    { typeof(CarSold), new CarSoldEventHandler() },
        //    { typeof(CarAquired), new CarAquiredEventHandler() },
        //    { typeof(CarRentalEstablished), new CarRentalEstablishedEventHandler() },
        //    { typeof(CarServiceNeedIdentified), new CarServiceNeededEventHandler() },
        //    // Car
        //    { typeof(DrivingStarted), new DrivingStartedEventHandler() },
        //    { typeof(DrivingStopped), new DrivingStoppedEventHandler() },
        //    { typeof(OwnerChanged), new OwnerChangedEventHandler() },
            
            

        //};

        //public static void RegisterModule(IDomainEventHandlerResolver module)
        //{
        //    foreach(var key in module.Handlers.Keys)
        //    {
        //        _eventHandlers[key] = module.Handlers[key];
        //    }
        //}

        public static void Publish(Event e, IDomainEventHandlerResolver resolver)
        {
            var type = e.GetType();
            var handler = resolver.ResolveHandler(type);
            handler.HandleEvent(e);
        }
    }
}
