using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Commands
{
    public class AquireCarCommand : Command<CarRental>
    {
        public AquireCarCommand(string registration, string seller, DateTime aquiredDate, DateTime registrationDate, string model, int milage)
        {
            Registration = registration;
            Seller = seller;
            AquiredDate = aquiredDate;
            RegistrationDate = registrationDate;
            Model = model;
            Milage = milage;
        }

        [Required, StringLength(7)]
        public string Registration { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required, StringLength(50)]
        public string Model { get; set; }

        [Required, StringLength(50)]
        public string Seller { get; set; }

        [Required, Range(0d, 100000d)]
        public int Milage { get; set; }
        [Required]
        public DateTime AquiredDate { get; set; }
    }
}
