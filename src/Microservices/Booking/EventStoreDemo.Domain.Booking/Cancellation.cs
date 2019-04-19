using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking
{
    public class Cancellation
    {
        public DateTime CancellationDate { get; set; }

        public int CancellationFee { get; set; }
    }
}
