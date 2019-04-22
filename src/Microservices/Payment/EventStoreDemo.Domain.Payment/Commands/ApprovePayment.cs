using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventStoreDemo.Domain.Payment.Commands
{
    public class ApprovePayment : Command<Payment>
    {
        [Required]
        public Guid PaymentReference { get; set; }
    }
}
