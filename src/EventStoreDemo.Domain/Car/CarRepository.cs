using EventStoreDemo.Domain.Car.Events;
using EventStoreDemo.Domain.CarRental.Events;
using EventStoreDemo.Domain.Events;
using EventStoreDemo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car
{
    public class CarRepository : RepositoryBase<Car>
    {
        private Dictionary<string, Car> GetAllDictionary()
        {
            var allCars = new Dictionary<string, Car>();
            var recordedEvents = GetEventsFromStream(Streams.CarRental);
            foreach (var re in recordedEvents)
            {
                switch (re.OriginalEvent.EventType)
                {
                    case "CarAquired":
                        var e = EventDataTo<CarAquired>(re.OriginalEvent);
                        var car = new Car
                        {
                            Model = e.Model,
                            Milage = e.Milage,
                            Registration = e.Registration
                        };
                        allCars[e.Registration] = car;
                        break;
                    default:
                        continue;
                }
            }
            recordedEvents = GetEventsFromStream(Streams.Car);
            foreach (var re in recordedEvents)
            {
                switch (re.OriginalEvent.EventType)
                {
                    case "DrivingStopped":
                        var e2 = EventDataTo<DrivingStopped>(re.OriginalEvent);
                        allCars[e2.Registration].Milage += e2.DistanceDriven;
                        break;
                }
            }
            return allCars;
        }

        public override IEnumerable<Car> GetAll()
        {
            return GetAllDictionary().Values;
        }

        public override Car GetOne(object key)
        {
            var registration = key.ToString();
            var cars = GetAllDictionary();
            if (!cars.ContainsKey(registration))
            {
                return null;
            }
            return cars[registration];
        }
    }
}
