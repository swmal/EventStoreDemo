using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Payment.Commands
{
    public class RevokePayment : Command<Payment>
    {
        public Guid PaymentReference { get; set; }

        public string RevokedBy { get; set; }
    }
}
