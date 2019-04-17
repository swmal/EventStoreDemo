using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Commands
{
    public class EstablishCarRental : Command<CarRental>
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
