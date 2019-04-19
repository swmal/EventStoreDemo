using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public abstract class CarRentalCommandHandlerBase : CommandHandler<CarRental>
    {
        public CarRentalCommandHandlerBase(Command<CarRental> command) : base(command)
        {
        }

        public CarRentalCommandHandlerBase(Command<CarRental> command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
        }

        public override IDomainEventHandlerResolver EventHandlerResolver => new DomainEventHandlerResolver();
    
    }
}
