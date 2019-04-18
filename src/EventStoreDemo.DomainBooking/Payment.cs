using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking
{
    public class Payment
    {
        public int Amount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
