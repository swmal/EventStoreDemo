using EventStoreDemo.Domain.CarRental.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public class SellCarCommandHandler : CarRentalCommandHandlerBase
    {
        public SellCarCommandHandler(SellCarCommand command) : base(command)
        {
            _command = command;
        }

        private readonly SellCarCommand _command;

        protected override void ExecuteCommand(CarRental aggregateRoot)
        {
            aggregateRoot.SellCar(_command.Registration, _command.SoldDate);
        }
    }
}
