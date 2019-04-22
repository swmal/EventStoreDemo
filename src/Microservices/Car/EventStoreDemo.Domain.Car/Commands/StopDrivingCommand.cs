using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.Car.CommandHandlers
{
    public class StopDrivingCommand : Command<Car>
    {
        [Required]
        public string Registration { get; set; }

        public Driver Driver { get; set; }

        [Required]
        public DateTime DrivingStoppedAt { get; set; }

        [Required, Range(1d, 1000d)]
        public int DistanceDriven { get; set; }
    }
}
