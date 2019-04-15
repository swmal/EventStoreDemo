using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Events
{
    public class CarAquired : Event
    {
        public string Registration { get; set; }

        public string CarRentalCode { get; set; }

        public string Model { get; set; }

        public string Seller { get; set; }

        public int Milage { get; set; }

        public DateTime AquiredDate{ get; set; }

        public override string Stream => Streams.CarRental;
    }
}
