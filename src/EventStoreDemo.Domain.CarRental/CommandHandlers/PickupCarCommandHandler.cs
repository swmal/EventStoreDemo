using EventStoreDemo.Domain.CarRental.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public class PickupCarCommandHandler : CommandHandler<CarRental>
    {
        public PickupCarCommandHandler(PickupCarCommand command) : base(command, new DomainEventHandlerResolver())
        {
            _command = command;
        }

        public PickupCarCommandHandler(PickupCarCommand command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
            _command = command;
        }

        private readonly PickupCarCommand _command;

        protected override void ExecuteCommand(CarRental aggregateRoot)
        {
            aggregateRoot.PickupCar(_command.Registration, _command.Driver, _command.PickedUpAt, _command.Milage);
        }
    }
}
