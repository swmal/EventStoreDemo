using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStoreDemo.Api.Models;
using EventStoreDemo.Domain;
using EventStoreDemo.Domain.Car;
using EventStoreDemo.Domain.Car.CommandHandlers;
using EventStoreDemo.Domain.Car.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EventStoreDemo.Api.Controllers
{
    [Route("api/car")]
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
                Model = x.Model,
                Milage = x.Milage
            }).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string code)
        {
            return "value";
        }

        // POST api/car/startdriving
        [HttpPost]
        public void StartDriving(string registration, string driver)
        {
            var car = _carRepository.GetOne(registration);
            var driveCommand = new StartDrivingCommand
            {
                Registration = registration,
                Driver = new Driver { Name = driver },
                DrivingStartedAt = DateTime.Now
            };
            var startDrivingHandler = new StartDrivingCommandHandler(driveCommand, car);
            startDrivingHandler.Execute();
        }

        // POST api/car/stopdriving
        [HttpPost]
        public void StopDriving(string registration, string driver, int distance)
        {
            var car = _carRepository.GetOne(registration);
            var stopCommand = new StopDrivingCommand
            {
                Registration = registration,
                Driver = new Driver { Name = driver },
                DrivingStoppedAt = DateTime.Now,
                DistanceDriven = distance
            };
            var stopDrivingHandler = new StopDrivingCommandHandler(stopCommand, car);
            stopDrivingHandler.Execute();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
