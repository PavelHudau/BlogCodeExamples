using System;
using System.Runtime.Serialization;

namespace DomainDrivenDesign.TableOrders
{
    public class InsufficientPaymentException : Exception
    {
        public InsufficientPaymentException()
        {
        }

        public InsufficientPaymentException(string message) : base(message)
        {
        }

        public InsufficientPaymentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientPaymentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
