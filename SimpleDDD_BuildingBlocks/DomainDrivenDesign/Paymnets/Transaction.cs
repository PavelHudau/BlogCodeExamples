using System;

namespace DomainDrivenDesign.Payments
{
    public class Transaction
    {
        public Transaction(Payment payment)
        {
            if (payment.Amount <= 0)
            {
                throw new ArgumentException("Payment amount should be greater than 0", nameof(payment));
            }

            Payment = payment;
            Id = Guid.NewGuid();
            OccurredOn = DateTime.Now;
            Status = TransactionStatus.Sending;
        }

        public Guid Id { get; set; }

        public Payment Payment { get; set; }

        public DateTime OccurredOn { get; set; }

        public TransactionStatus Status { get; private set; }

        // Implementing Equality operator.
        public static bool operator ==(Transaction a, Transaction b) => a.Id == b.Id;

        // Implementing Non-Equality operator.
        public static bool operator !=(Transaction a, Transaction b) => a.Id != b.Id;

        public void BeginProcess()
        {
            Status = TransactionStatus.Pending;
        }

        public void CompleteTransaction()
        {
            Status = TransactionStatus.Completed;
        }

        // Need to override object.Equals()
        public override bool Equals(object obj)
        {
            return obj is Transaction transaction &&
                    this == transaction;
        }

        // And also need to override object.GetHashCode()
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
