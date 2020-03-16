using System;

namespace DomainDrivenDesign.Payments
{
    public struct Payment
    {
        public Payment(
            PaymentType paymentType,
            decimal amount,
            Currency currency)
        {
            PaymentType = paymentType;
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; private set; }

        public Currency Currency { get; private set; }

        public PaymentType PaymentType { get; private set; }

        // Implementing Equality operator
        public static bool operator ==(Payment a, Payment b) =>
            a.Amount == b.Amount &&
            a.Currency == b.Currency &&
            a.PaymentType == b.PaymentType;

        // Implementing Non-Equality operator
        public static bool operator !=(Payment a, Payment b) => !(a == b);

        // Need to override object.Equals()
        public override bool Equals(object obj)
        {
            return obj is Payment payment &&
                   this == payment;
        }

        // And also need to override object.GetHashCode()
        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency, PaymentType);
        }
    }
}
