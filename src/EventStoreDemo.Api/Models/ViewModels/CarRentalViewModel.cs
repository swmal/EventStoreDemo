using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStoreDemo.Api.Models
{
    public class CarRentalViewModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime EstablishDate { get; set; }
    }
}
