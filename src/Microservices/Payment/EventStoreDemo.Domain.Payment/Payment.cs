using EventStoreDemo.Domain.Payment.Events;
using System;

namespace EventStoreDemo.Domain.Payment
{
    public class Payment : AggregateRoot
    {
        public string InternalReference { get; set; }
        public Guid PaymentReference { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }


        public void PerformPayment(string internalRef, decimal amount, string currency)
        {
            var payRef = Guid.NewGuid();
            InternalReference = internalRef;
            PaymentReference = payRef;
            Amount = amount;
            Currency = currency;
            AddEvent(new PaymentPerformed
            {
                InternalReference = internalRef,
                PaymentReference = payRef,
                Amount = amount,
                Currency = currency
            });
        }
    }
}
