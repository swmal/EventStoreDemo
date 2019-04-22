using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.Car.Events
{
    public class CarAquired : Event
    {
        [Required, StringLength(7)]
        public string Registration { get; set; }
        [Required, StringLength(2)]
        public string CarRentalCode { get; set; }
        [Required]
        public string Model { get; set; }
        [Required, Range(0d, 100000d)]
        public int Milage { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        public override string Stream => Streams.Car;
    }
}
