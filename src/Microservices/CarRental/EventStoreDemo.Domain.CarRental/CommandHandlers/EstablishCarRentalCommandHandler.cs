using EventStoreDemo.Domain.CarRental.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public class EstablishCarRentalCommandHandler : CarRentalCommandHandlerBase<EstablishCarRental>
    {
        public EstablishCarRentalCommandHandler(EstablishCarRental command) : base(command)
        {
        }

        public EstablishCarRentalCommandHandler(EstablishCarRental command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
        }

        protected override void ExecuteCommand(CarRental aggregateRoot, EstablishCarRental command)
        {
            aggregateRoot.Establish(command.Name, command.Code);
        }
    }
}
