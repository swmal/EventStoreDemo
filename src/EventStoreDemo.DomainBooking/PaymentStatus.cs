using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Booking
{
    public enum PaymentStatus
    {
        NoPaymentReceived,
        RegistrationFeePaid,
        FullPaymentReceived
    }
}
