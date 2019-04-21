using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Payment
{
    public enum PaymentStatus
    {
        Pending,
        Approved,
        Revoked
    }
}
