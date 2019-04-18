using EventStoreDemo.Domain.Booking.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.CommandHandlers
{
    public abstract class BookingCommandHandlerBase : CommandHandler<Booking>
    {
        public BookingCommandHandlerBase(Command<Booking> command) : base(command)
        {
        }

        public BookingCommandHandlerBase(Command<Booking> command, Booking aggregateRoot) : base(command, aggregateRoot)
        {
        }

        protected override void OnCommandExecuted(Booking aggregateRoot)
        {
            // save to repo
            var repository = new BookingRepository();
            repository.InsertOrUpdate(aggregateRoot);
        }

        public override IDomainEventHandlerResolver EventHandlerResolver => new DomainEventHandlerResolver();
    }
}
