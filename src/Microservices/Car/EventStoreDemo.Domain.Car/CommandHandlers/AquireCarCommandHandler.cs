using EventStoreDemo.Domain.Car.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Car.CommandHandlers
{
    public class AquireCarCommandHandler : CarCommandHandlerBase<AquireCar>
    {
        public AquireCarCommandHandler(AquireCar command) : base(command)
        {
        }

        public AquireCarCommandHandler(AquireCar command, Car aggregate) : base(command, aggregate)
        {
        }

        protected override void ExecuteCommand(Car car, AquireCar c)
        {
            car.Aquire(c.Registration, c.CarRentalCode, c.Model, c.Milage, c.RegistrationDate);
        }
    }
}
