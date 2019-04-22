using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Commands
{
    public class ReturnCarCommand : Command<CarRental>
    {
        public ReturnCarCommand(CarInfo car, Driver driver, DateTime returnDate)
        {
            Car = car;
            Driver = driver;
            ReturnedAt = returnDate;
        }

        [Required]
        public CarInfo Car { get; private set; }

        [Required]
        public Driver Driver { get; private set; }

        [Required]
        public DateTime ReturnedAt { get; private set; }

    }
}
