using EventStoreDemo.Domain.Booking.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.CommandHandlers
{
    public class CreateBookingCommandHandler : BookingCommandHandlerBase<CreateBooking>
    {
        public CreateBookingCommandHandler(CreateBooking command) : base(command)
        {
        }

        public CreateBookingCommandHandler(CreateBooking command, Booking aggregateRoot) : base(command, aggregateRoot)
        {
        }

        protected override void ExecuteCommand(Booking booking, CreateBooking command)
        {
            booking.CreateBooking(command.Info, command.Customer);
        }
    }
}
