using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Payments
{
    public interface IElectronicTransactionProcessor
    {
        void BeginProcessTransaction(Transaction transaction);
    }
}
