using EventStoreDemo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Payment.Events
{
    public class PaymentPerformed : Event
    {
        public Guid PaymentReference { get; set; }

        public string InternalReference { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public override string Stream => Streams.Payment;
    }
}
