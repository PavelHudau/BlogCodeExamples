namespace DomainDrivenDesign.Payments
{
    public interface IPaymentProcessor
    {
        Transaction ProcessPayment(Payment payment);
    }
}