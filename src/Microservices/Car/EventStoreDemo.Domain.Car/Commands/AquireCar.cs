using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.Commands
{
    public class AquireCar : Command<Car>
    {
        public string Registration { get; set; }

        public string Model { get; set; }

        public int Milage { get; set; }

        public DateTime RegistrationDate { get; set; }

    }
}
