using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.Commands
{
    public class StartDrivingCommand : Command<Car>
    {
        public string Registration { get; set; }

        public Driver Driver { get; set; }

        public DateTime DrivingStartedAt { get; set; }
    }
}
