using EventStoreDemo.Domain.Booking.Events;
using EventStoreDemo.Domain.EventHandlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking.EventHandlers
{
    public class BookingCancelledEventHandler : DomainEventHandler<BookingCancelled>
    {
    }
}
