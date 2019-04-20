using EventStoreDemo.Domain.Booking.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.CommandHandlers
{
    public class CancelBookingCommandHandler : BookingCommandHandlerBase<CancelBooking>
    {
        public CancelBookingCommandHandler(CancelBooking command) : base(command)
        {
        }

        public CancelBookingCommandHandler(CancelBooking command, Booking aggregateRoot) : base(command, aggregateRoot)
        {
        }

        protected override void ExecuteCommand(Booking booking, CancelBooking command)
        {
            booking.CancelBooking(command.CancelledBy, DateTime.Now);
        }
    }
}
