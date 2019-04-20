using EventStoreDemo.Domain.Payment.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Payment.CommandHandlers
{
    public class PerformPaymentCommandHandler : PaymentCommandHandlerBase<PerformPayment>
    {
        public PerformPaymentCommandHandler(PerformPayment command) : base(command)
        {
        }

        public PerformPaymentCommandHandler(PerformPayment command, Payment aggregateRoot) : base(command, aggregateRoot)
        {
        }

        protected override void ExecuteCommand(Payment aggregateRoot, PerformPayment command)
        {
            throw new NotImplementedException();
        }
    }
}
