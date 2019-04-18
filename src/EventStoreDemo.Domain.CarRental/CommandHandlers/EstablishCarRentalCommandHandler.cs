using EventStoreDemo.Domain.CarRental.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public class EstablishCarRentalCommandHandler : CarRentalCommandHandlerBase
    {
        public EstablishCarRentalCommandHandler(EstablishCarRental command) : base(command)
        {
            _command = command;
        }

        public EstablishCarRentalCommandHandler(EstablishCarRental command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
            _command = command;
        }
        
        private readonly EstablishCarRental _command;

        protected override void ExecuteCommand(CarRental aggregateRoot)
        {
            aggregateRoot.Establish(_command.Name, _command.Code);
        }
    }
}
