using EventStoreDemo.Domain.CarRental.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public class ReturnCarCommandHandler : CarRentalCommandHandlerBase<ReturnCarCommand>
    {
        public ReturnCarCommandHandler(ReturnCarCommand command) : base(command)
        {
        }

        public ReturnCarCommandHandler(ReturnCarCommand command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
        }

        protected override void ExecuteCommand(CarRental carRental, ReturnCarCommand command)
        {
            carRental.ReturnCar(command.Car, command.Driver, command.ReturnedAt);
        }
    }
}
