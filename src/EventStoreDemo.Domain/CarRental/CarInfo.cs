using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental
{
    public class CarInfo
    {
        public string Registration { get; set; }

        public string RegistrationDate { get; set; }

        public string Model { get; set; }

        public int Milage { get; set; }

        public bool NeedsService { get; set; }
    }
}
