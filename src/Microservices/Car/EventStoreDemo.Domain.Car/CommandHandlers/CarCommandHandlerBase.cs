using System;
using System.Collections.Generic;
using System.Text;


namespace EventStoreDemo.Domain.Car.CommandHandlers
{
    public abstract class CarCommandHandlerBase : CommandHandler<Car>
    {
        public CarCommandHandlerBase(Command<Car> command) : base(command)
        {

        }

        public CarCommandHandlerBase(Command<Car> command, Car aggregate) : base(command, aggregate)
        {

        }
        public override IDomainEventHandlerResolver EventHandlerResolver => new DomainEventHandlerResolver();

    }
}
