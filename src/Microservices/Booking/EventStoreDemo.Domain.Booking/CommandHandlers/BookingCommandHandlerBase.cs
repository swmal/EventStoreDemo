using EventStoreDemo.Domain.Booking.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.CommandHandlers
{
    public abstract class BookingCommandHandlerBase<T1> : CommandHandler<Booking, T1>
        where T1 : Command<Booking>
    {
        public BookingCommandHandlerBase(T1 command) : base(command)
        {
        }

        public BookingCommandHandlerBase(T1 command, Booking aggregateRoot) : base(command, aggregateRoot)
        {
        }

        protected override void OnCommandExecuted(Booking aggregateRoot)
        {
            // save to repo
            var repository = new BookingRepository();
            repository.InsertOrUpdate(aggregateRoot);
        }

        public override sealed IDomainEventHandlerResolver EventHandlerResolver => new DomainEventHandlerResolver();
    }
}
