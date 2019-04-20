using System;
using System.Collections.Generic;
using System.Text;

namespace EventStoreDemo.Domain.Payment.CommandHandlers
{
    public abstract class PaymentCommandHandlerBase<T1> : CommandHandler<Payment, T1>
        where T1 : Command<Payment>
    {
        public PaymentCommandHandlerBase(T1 command) : base(command)
        {
        }

        public PaymentCommandHandlerBase(T1 command, Payment aggregateRoot) : base(command, aggregateRoot)
        {
        }

        public override IDomainEventHandlerResolver EventHandlerResolver => new DomainEventHandlerResolver();
    
    }
}
