using System;
using System.Collections.Generic;
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

        public CarInfo Car { get; private set; }

        public Driver Driver { get; private set; }

        public DateTime ReturnedAt { get; private set; }

    }
}
