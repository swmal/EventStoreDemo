using EventStoreDemo.Domain.Car.Events;
using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car
{
    public class Car : AggregateRoot
    {
        public string Model { get; set; }

        public int Milage { get; set; }

        public DateTime LastServiceDate { get; private set; }

        public int MilageAtLastService { get; private set; }

        public string Registration { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool NeedsService()
        {
            if(DateTime.Now > LastServiceDate.AddYears(1) || Milage > (1500 + MilageAtLastService))
            {
                return true;
            }
            return false;
        }

        public void StartDriving(DateTime startTime, Driver driver)
        {
            var reg = Registration;
            AddEvent(new DrivingStarted {
                Registration = reg,
                DrivingStartedAt = startTime,
                Driver = driver
            });
        }

        public void StopDriving(DateTime stopTime, Driver driver, int distanceDriven)
        {
            var reg = Registration;
            AddEvent(new DrivingStopped
            {
                Registration = reg,
                DrivingStoppedAt = stopTime,
                Driver =  driver,
                DistanceDriven = distanceDriven
            });
        }
    }
}
