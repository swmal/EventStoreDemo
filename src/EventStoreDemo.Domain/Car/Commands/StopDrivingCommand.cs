using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.CommandHandlers
{
    public class StopDrivingCommand : Command<Car>
    {
        public string Registration { get; set; }

        public Driver Driver { get; set; }

        public DateTime DrivingStoppedAt { get; set; }

        public int DistanceDriven { get; set; }
    }
}
