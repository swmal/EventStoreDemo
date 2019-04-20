
using EventStoreDemo.Domain.CarRental;
using EventStoreDemo.Domain.CarRental.CommandHandlers;
using EventStoreDemo.Domain.CarRental.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EventDemo.Domain.Tests
{
    [TestClass]
    public class SomeTests
    {
        [TestInitialize]
        public void Initialize()
        {
            _carRental = new CarRental
            {
                Name = "Mats Alms biluthyrning",
                Code = "MA"
            };
            //_xc60 = new Car
            //{
            //    Registration = "ABC 123", Milage = 0, Model = "Volvo XC60"
            //};
        }

        private CarRental _carRental;
        //private Car _xc60;

        [TestMethod]
        public void InitializeWithTwoVolvos()
        {
            var carRental = new CarRental();
            var c1 = new EstablishCarRental
            {
                Name = "Mats Alms biluthyrning",
                Code = "MA"
            };
            var ch1 = new EstablishCarRentalCommandHandler(c1, carRental);
            ch1.Execute();

            // Add an xc 60
            var regDate1 = new DateTime(2018, 10, 10);
            var c2 = new AquireCarCommand("ABC 123", "Bilia", DateTime.Now, regDate1, "Volvo XC60", 0);
            var ch2 = new AquireCarCommandHandler(c2, carRental);
            ch2.Execute();

            // Add a V90
            var regDate2 = new DateTime(2018, 8, 8);
            var c3 = new AquireCarCommand("DEF 456", "Bilia", DateTime.Now, regDate2, "Volvo V90", 0);
            var ch3 = new AquireCarCommandHandler(c3, carRental);
            ch3.Execute();

            
        }

        /*
        [TestMethod]
        public void PickupAndDrive()
        {
            // Pickup and drive
            var pickUpCommand = new PickupCarCommand
            {
                Registration = "ABC 123",
                Driver = new EventStoreDemo.Domain.CarRental.Driver { Name = "Mats" },
                Milage = 0,
                PickedUpAt = DateTime.Parse("2019-02-02T12:00")
            };
            var pickupHandler = new PickupCarCommandHandler(pickUpCommand, _carRental);
            pickupHandler.Execute();

            var driveCommand = new StartDrivingCommand
            {
                Registration = "ABC 123",
                Driver = new EventStoreDemo.Domain.Car.Driver { Name = "Mats"},
                DrivingStartedAt = DateTime.Parse("2019-02-02T12:06")
            };
            var startDrivingHandler = new StartDrivingCommandHandler(driveCommand, _xc60);
            startDrivingHandler.Execute();

            var stopCommand = new StopDrivingCommand
            {
                Registration = "ABC 123",
                Driver = new EventStoreDemo.Domain.Car.Driver { Name = "Mats" },
                DrivingStoppedAt = DateTime.Parse("2019-02-02T12:06"),
                DistanceDriven = 105
            };
            var stopDrivingHandler = new StopDrivingCommandHandler(stopCommand, _xc60);
            stopDrivingHandler.Execute();
        }
        */
    }
}
