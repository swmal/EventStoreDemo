using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Commands
{
    public class PickupCarCommand : Command<CarRental>
    {
        public string Registration { get; set; }

        public Driver Driver { get; set; }

        public DateTime PickedUpAt { get; set; }

        public int Milage { get; set; }
    }
}
