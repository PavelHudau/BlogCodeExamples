using System;

namespace DomainDrivenDesign.Payments
{
    public class PaymentProcessor : IPaymentProcessor
    {
        private readonly IElectronicTransactionProcessor _electronicTransactionProcessor;
        private readonly ICheckClearingService _checkClearingService;

        public PaymentProcessor(
            IElectronicTransactionProcessor electronicTransactionProcessor,
            ICheckClearingService checkClearingService)
        {
            _electronicTransactionProcessor = electronicTransactionProcessor ??
                throw new AccessViolationException(nameof(electronicTransactionProcessor));
            _checkClearingService = checkClearingService ??
                throw new ArgumentNullException(nameof(checkClearingService));
        }

        public Transaction ProcessPayment(Payment payment)
        {
            var transaction = new Transaction(payment);

            switch (payment.PaymentType)
            {
                case PaymentType.Cash:
                    transaction.CompleteTransaction();
                    break;
                case PaymentType.Check:
                    _checkClearingService.BeginClearingCheck(transaction.Payment);
                    transaction.BeginProcess();
                    break;
                case PaymentType.Visa:
                case PaymentType.MasterCard:
                case PaymentType.AmericanExpress:
                    _electronicTransactionProcessor.BeginProcessTransaction(transaction);
                    transaction.BeginProcess();
                    break;
            }

            return transaction;
        }
    }
}
