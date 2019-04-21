using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Payment.Commands
{
    public class ApprovePayment : Command<Payment>
    {
        public Guid PaymentReference { get; set; }
    }
}
