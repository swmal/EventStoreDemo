using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Payment.Events
{
    public class PaymentApproved : Event
    {
        public Guid PaymentReference { get; set; }

        public override string Stream => Streams.Payment;
    }
}
