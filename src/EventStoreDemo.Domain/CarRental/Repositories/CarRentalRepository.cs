using EventStoreDemo.Domain.Car.EventsRental;
using EventStoreDemo.Domain.Events;
using EventStoreDemo.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Repositories
{
    public class CarRentalRepository : RepositoryBase<CarRental>
    {
        private Dictionary<string, CarRental> GetAllDictionary()
        {
            var allRentals = new Dictionary<string, CarRental>();
            var recordedEvents = GetEventsFromStream(Streams.CarRental);
            foreach(var re in recordedEvents)
            {
                switch(re.OriginalEvent.EventType)
                {
                    case "CarRentalEstablished":
                        var e = EventDataTo<CarRentalEstablished>(re.OriginalEvent);
                        var rental = new CarRental();
                        rental.Name = e.Name;
                        rental.Code = e.Code;
                        allRentals[e.Code] = rental;
                        break;
                    default:
                        continue;
                }
            }
            return allRentals;
        }

        public override IEnumerable<CarRental> GetAll()
        {
            return GetAllDictionary().Values;
        }

        public override CarRental GetOne(object key)
        {
            var code = key.ToString();
            var rentals = GetAllDictionary();
            if(!rentals.ContainsKey(code))
            {
                throw new InvalidOperationException("There is no CarRental with the code " + code);
            }
            return rentals[code];
        }
    }
}
