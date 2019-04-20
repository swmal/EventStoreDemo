using System;
using System.Collections.Generic;
using System.Text;


namespace EventStoreDemo.Domain.Car.CommandHandlers
{
    public abstract class CarCommandHandlerBase<T1> : CommandHandler<Car, T1>
        where T1 : Command<Car>
    {
        public CarCommandHandlerBase(T1 command) : base(command)
        {

        }

        public CarCommandHandlerBase(T1 command, Car aggregate) : base(command, aggregate)
        {

        }
        public override IDomainEventHandlerResolver EventHandlerResolver => new DomainEventHandlerResolver();

    }
}
