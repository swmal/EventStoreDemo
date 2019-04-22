using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Commands
{
    public class PickupCarCommand : Command<CarRental>
    {
        [Required, StringLength(7)]
        public string Registration { get; set; }

        public Driver Driver { get; set; }

        [Required]
        public DateTime PickedUpAt { get; set; }

        [Required, Range(0d, 100000d)]
        public int Milage { get; set; }
    }
}
