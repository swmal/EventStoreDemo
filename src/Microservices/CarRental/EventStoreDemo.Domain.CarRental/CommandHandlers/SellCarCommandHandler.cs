using EventStoreDemo.Domain.CarRental.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public class SellCarCommandHandler : CarRentalCommandHandlerBase<SellCarCommand>
    {
        public SellCarCommandHandler(SellCarCommand command) : base(command)
        {
        }

        public SellCarCommandHandler(SellCarCommand command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
        }

        protected override void ExecuteCommand(CarRental aggregateRoot, SellCarCommand command)
        {
            aggregateRoot.SellCar(command.Registration, command.SoldDate);
        }
    }
}
