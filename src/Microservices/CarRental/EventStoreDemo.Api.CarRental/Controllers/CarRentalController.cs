using EventStoreDemo.Api.Models;
using EventStoreDemo.Domain.CarRental.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStoreDemo.Api.Controllers
{
    [Route("api/carrental")]
    [ApiController]
    public class CarRentalController
    {
        private readonly CarRentalRepository _carRentalRepository = new CarRentalRepository();
        [HttpGet]
        public IEnumerable<CarRentalViewModel> Get()
        {
            var rentals = _carRentalRepository.GetAll();
            return rentals.Select(x => new CarRentalViewModel
            {
                Name = x.Name,
                Code = x.Code,
                EstablishDate = DateTime.Now
            }).ToList();
        }
    }
}
