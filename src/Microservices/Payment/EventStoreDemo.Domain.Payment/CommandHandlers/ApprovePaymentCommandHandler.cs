using EventStoreDemo.Domain.Payment.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Payment.CommandHandlers
{
    public class ApprovePaymentCommandHandler : CommandHandler<Payment, ApprovePayment>
    {
        public ApprovePaymentCommandHandler(ApprovePayment command) : base(command)
        {
        }

        public ApprovePaymentCommandHandler(ApprovePayment command, Payment aggregateRoot) : base(command, aggregateRoot)
        {
        }

        public override IDomainEventHandlerResolver EventHandlerResolver => throw new NotImplementedException();

        protected override void ExecuteCommand(Payment aggregateRoot, ApprovePayment command)
        {
            throw new NotImplementedException();
        }
    }
}
