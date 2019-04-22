using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.Car.Commands
{
    public class StartDrivingCommand : Command<Car>
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(7)]
        public string Registration { get; set; }

        public Driver Driver { get; set; }
        [Required]
        public DateTime DrivingStartedAt { get; set; }
    }
}
