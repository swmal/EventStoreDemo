using EventStoreDemo.Domain.Booking.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.EventHandlers
{
    public class BookingCreatedEventHandler : DomainEventHandler<BookingCreated>
    {
    }
}
