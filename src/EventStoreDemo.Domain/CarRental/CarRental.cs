using EventStoreDemo.Domain.Car.Events;
using EventStoreDemo.Domain.Car.EventsRental;
using EventStoreDemo.Domain.CarRental.Events;
using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental
{
    public class CarRental : AggregateRoot
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime EstablishDate { get; set; }

        public void Establish(string name, string code)
        {
            Name = name;
            Code = code;
            EstablishDate = DateTime.Now;
            AddEvent(new CarRentalEstablished
            {
                Name = name,
                Code = code,
                EstablishedDate = DateTime.Now
            });
        }
        public void AquireCar(string registration, string model, string seller, DateTime aquiredDate, DateTime registrationDate, int milage)
        {
            AddEvent(new CarAquired
            {
                Registration = registration,
                RegistrationDate = registrationDate,
                Model = model,
                CarRentalCode = Code,
                Seller = seller,
                AquiredDate = aquiredDate,
                Milage = milage
            });
            AddEvent(new OwnerChanged
            {
                Registration = registration,
                ChangeDate = aquiredDate,
                PreviousOwner = seller,
                NewOwner = Name
            });
        }

        public void SellCar(string registration, DateTime soldDate)
        {
            AddEvent(new CarSold
            {
                Registration = registration,
                SoldDate = soldDate
            });
        }

        public void PickupCar(string registration, Driver driver, DateTime pickedUpAt, int milage)
        {
            AddEvent(new CarPickedUp
            {
                Registration = registration,
                Driver = driver,
                Milage = milage,
                PickedUpAt = pickedUpAt
            });
        }

        public void ReturnCar(CarInfo car, Driver driver, DateTime returnedAt)
        {
            AddEvent(new CarReturned
            {
                Registration = car.Registration,
                Driver = driver,
                Milage = car.Milage,
                ReturnedAt = returnedAt
            });
            if(car.Milage > 10000)
            {
                AddEvent(new CarSold
                {
                    Registration = car.Registration,
                    SoldDate = returnedAt.AddDays(1)
                });
                AddEvent(new OwnerChanged
                {
                    Registration = car.Registration,
                    ChangeDate = returnedAt.AddDays(1),
                    PreviousOwner = Name,
                    NewOwner = "Some lucky guy..."
                });
            }
            // check if car needs service
            else if(car.NeedsService)
            {
                AddEvent(new CarServiceNeedIdentified
                {
                    Registration = car.Registration
                });
            }
        }
    }
}
