using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Payment.Commands
{
    public class PerformPayment : Command<Payment>
    {
        public Guid PaymentReference { get; set; }
        public string InternalReference { get; set; }
        public decimal Amount { get; set; }

        public string Currency { get; set; }
    }
}
