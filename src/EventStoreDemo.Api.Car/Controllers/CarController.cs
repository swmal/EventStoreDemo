using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EventStoreDemo.Api.Models;
using EventStoreDemo.Api.Models.InputModels;
using EventStoreDemo.Domain;
using EventStoreDemo.Domain.Car;
using EventStoreDemo.Domain.Car.CommandHandlers;
using EventStoreDemo.Domain.Car.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EventStoreDemo.Api.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRepository _carRepository = new CarRepository();
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CarViewModel>> Get()
        {
            var cars = _carRepository.GetAll();
            return cars.Select(x => new CarViewModel
            {
                Registration = x.Registration,
                RegistrationDate = x.RegistrationDate,
                Model = x.Model,
                Milage = x.Milage
            }).ToList();
        }

        // GET api/cars/{registration}
        [HttpGet("{registration}")]
        public ActionResult<CarViewModel> Get(string registration)
        {
            var car = _carRepository.GetOne(registration);
            if (car == null) return NotFound();
            var viewModel = new CarViewModel
            {
                Registration = car.Registration,
                RegistrationDate = car.RegistrationDate,
                Milage = car.Milage
            };
            return Ok(viewModel);
        }

        // POST api/car/startdriving
        [HttpPost, Route("/api/cars/{registration}/usage/start")]
        public StatusCodeResult Start([FromRoute]string registration, [FromBody]StartDrivingInputModel model)
        {
            var car = _carRepository.GetOne(registration);
            if (car == null) return NotFound();
            var driveCommand = new StartDrivingCommand
            {
                Registration = registration,
                Driver = new Driver { Name = model.Driver },
                DrivingStartedAt = DateTime.Now
            };
            var startDrivingHandler = new StartDrivingCommandHandler(driveCommand, car);
            startDrivingHandler.Execute();
            return Ok();
        }

        // POST api/car/stopdriving
        [HttpPost, Route("/api/cars/{registration}/usage/stop")]
        public StatusCodeResult StopDriving([FromRoute]string registration, [FromBody]StopDrivingInputModel model)
        {
            var car = _carRepository.GetOne(registration);
            if (car == null) return NotFound();
            var stopCommand = new StopDrivingCommand
            {
                Registration = registration,
                Driver = new Driver { Name = model.Driver },
                DrivingStoppedAt = DateTime.Now,
                DistanceDriven = model.DistanceDriven
            };
            var stopDrivingHandler = new StopDrivingCommandHandler(stopCommand, car);
            stopDrivingHandler.Execute();
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
