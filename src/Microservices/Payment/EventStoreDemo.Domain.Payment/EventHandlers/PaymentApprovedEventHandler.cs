using EventStoreDemo.Domain.Payment.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Payment.EventHandlers
{
    public class PaymentApprovedEventHandler : DomainEventHandler<PaymentApproved>
    {
    }
}
