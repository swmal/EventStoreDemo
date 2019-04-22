using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.Car.Events
{
    public class OwnerChanged : Event
    {
        [Required]
        public string Registration { get; set; }
        [Required]
        public string PreviousOwner { get; set; }
        [Required]
        public string NewOwner { get; set; }

        public DateTime ChangeDate { get; set; }
        public override string Stream => Streams.Car;
    }
}
