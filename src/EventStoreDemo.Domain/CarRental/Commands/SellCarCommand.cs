using System;
using System.Collections.Generic;
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

        public string Registration { get; set; }

        public DateTime SoldDate { get; set; }
    }
}
