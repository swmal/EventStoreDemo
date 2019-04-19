using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStoreDemo.Api.Car.Models
{
    public class CarViewModel
    {
        public string Registration { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string Model { get; set; }

        public int Milage { get; set; }
    }
}
