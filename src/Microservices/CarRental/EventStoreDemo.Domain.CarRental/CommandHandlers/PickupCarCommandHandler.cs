using EventStoreDemo.Domain.CarRental.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public class PickupCarCommandHandler : CarRentalCommandHandlerBase<PickupCarCommand>
    {
        public PickupCarCommandHandler(PickupCarCommand command) : base(command)
        {
        }

        public PickupCarCommandHandler(PickupCarCommand command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
        }

        protected override void ExecuteCommand(CarRental aggregateRoot, PickupCarCommand command)
        {
            aggregateRoot.PickupCar(command.Registration, command.Driver, command.PickedUpAt, command.Milage);
        }
    }
}
