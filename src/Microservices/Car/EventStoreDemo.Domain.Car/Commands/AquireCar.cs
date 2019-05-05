using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.Car.Commands
{
    public class AquireCar : Command<Car>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage ="Registration is required")]
        [StringLength(7)]
        public string Registration { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Car rental code is required")]
        public string CarRentalCode { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(0, 100000)]
        public int Milage { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

    }
}
