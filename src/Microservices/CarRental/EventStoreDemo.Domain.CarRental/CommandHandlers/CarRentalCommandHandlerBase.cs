using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.CarRental.CommandHandlers
{
    public abstract class CarRentalCommandHandlerBase<T1> : CommandHandler<CarRental, T1>
        where T1 : Command<CarRental>
    {
        public CarRentalCommandHandlerBase(T1 command) : base(command)
        {
        }

        public CarRentalCommandHandlerBase(T1 command, CarRental aggregateRoot) : base(command, aggregateRoot)
        {
        }

        public override sealed IDomainEventHandlerResolver EventHandlerResolver => new DomainEventHandlerResolver();
    
    }
}
