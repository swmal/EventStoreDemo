using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.Car.Events
{
    public class DrivingStopped : Event
    {
        [Required]
        public string Registration { get; set; }

        public Driver Driver { get; set; }

        [Required]
        public DateTime DrivingStoppedAt { get; set; }
        [Required]
        public int DistanceDriven { get; set; }

        public override string Stream => Streams.Car;
    }
}
