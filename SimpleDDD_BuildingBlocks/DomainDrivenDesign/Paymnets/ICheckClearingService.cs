using System;
using System.Collections.Generic;
using System.Text;

namespace DomainDrivenDesign.Payments
{
    public interface ICheckClearingService
    {
        void BeginClearingCheck(Payment checkPayment);
    }
}
