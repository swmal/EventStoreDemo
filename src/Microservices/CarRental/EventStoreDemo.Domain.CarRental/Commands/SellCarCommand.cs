using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Commands
{
    public class SellCarCommand : Command<CarRental>
    {
        public SellCarCommand(string registration, DateTime soldDate)
        {
            Registration = registration;
            SoldDate = soldDate;
        }

        [Required, StringLength(7)]
        public string Registration { get; set; }

        [Required]
        public DateTime SoldDate { get; set; }
    }
}
