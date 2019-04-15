using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Commands
{
    public class AquireCarCommand : Command<CarRental>
    {
        public AquireCarCommand(string registration, string seller, DateTime aquiredDate, string model, int milage)
        {
            Registration = registration;
            Seller = seller;
            AquiredDate = aquiredDate;
            Model = model;
            Milage = milage;
        }

        public string Registration { get; set; }

        public string Model { get; set; }

        public string Seller { get; set; }

        public int Milage { get; set; }

        public DateTime AquiredDate { get; set; }
    }
}
