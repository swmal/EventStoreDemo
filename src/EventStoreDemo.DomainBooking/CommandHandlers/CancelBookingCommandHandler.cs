using EventStoreDemo.Domain.Booking.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.CommandHandlers
{
    public class CancelBookingCommandHandler : BookingCommandHandlerBase
    {
        public CancelBookingCommandHandler(CancelBooking command) : base(command)
        {
            _command = command;
        }

        public CancelBookingCommandHandler(CancelBooking command, Booking aggregateRoot) : base(command, aggregateRoot)
        {
            _command = command;
        }

        private readonly CancelBooking _command;

        protected override void ExecuteCommand(Booking booking)
        {
            booking.CancelBooking(_command.CancelledBy, DateTime.Now);
        }
    }
}
