using System;
using System.Runtime.Serialization;

namespace DomainDrivenDesign.TableOrders
{
    public class UnsupportedCurrencyException : Exception
    {
        public UnsupportedCurrencyException()
        {
        }

        public UnsupportedCurrencyException(string message) : base(message)
        {
        }

        public UnsupportedCurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnsupportedCurrencyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
