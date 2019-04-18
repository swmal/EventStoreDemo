using EventStoreDemo.Domain.CarRental.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public class ReturnCarCommandHandler : CarRentalCommandHandlerBase
    {
        public ReturnCarCommandHandler(ReturnCarCommand command) : base(command)
        {
            _command = command;
        }

        public ReturnCarCommandHandler(ReturnCarCommand command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
            _command = command;
        }

        private readonly ReturnCarCommand _command;

        protected override void ExecuteCommand(CarRental carRental)
        {
            carRental.ReturnCar(_command.Car, _command.Driver, _command.ReturnedAt);
        }
    }
}
