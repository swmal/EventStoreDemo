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

        public PaymentStatus Status { get; set; }


        public void PerformPayment(string internalRef, decimal amount, string currency)
        {
            Status = PaymentStatus.Pending;
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

        public void ApprovePayment(Guid paymentRef)
        {
            Status = PaymentStatus.Approved;
            AddEvent(new PaymentApproved
            {
                PaymentReference = paymentRef
            });
        }

        public void RevokePayment(Guid paymentRef, string revokedBy)
        {
            Status = PaymentStatus.Revoked;
            AddEvent(new PaymentRevoked {
                PaymentReference = paymentRef,
                RevokedBy = revokedBy
            });
        }
    }
}
