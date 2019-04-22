using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.Commands
{
    public class EstablishCarRental : Command<CarRental>
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(2), RegularExpression("[A-Z]")]
        public string Code { get; set; }
    }
}
