using EventStoreDemo.Domain.Booking.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.CommandHandlers
{
    public class CreateBookingCommandHandler : BookingCommandHandlerBase
    {
        public CreateBookingCommandHandler(CreateBooking command) : base(command)
        {
            _command = command;
        }

        public CreateBookingCommandHandler(CreateBooking command, Booking aggregateRoot) : base(command, aggregateRoot)
        {
            _command = command;
        }

        private readonly CreateBooking _command;

        protected override void ExecuteCommand(Booking booking)
        {
            booking.CreateBooking(_command.Info, _command.Customer);
        }
    }
}
