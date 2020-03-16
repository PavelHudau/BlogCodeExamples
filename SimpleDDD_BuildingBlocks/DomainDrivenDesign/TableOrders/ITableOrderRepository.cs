using DomainDrivenDesign.Common;
using System;
using System.Collections.Generic;

namespace DomainDrivenDesign.TableOrders
{
    public interface ITableOrderRepository
    {
        TableOrder FindTableOrder(Guid tebleOrderId);

        TableOrder SaveTableOrder(TableOrder tableOrder);

        void DeleteTableOrder(TableOrder tableOrder);

        IEnumerable<TableOrder> FindAllTableOrders(TimeInterval period);

        IEnumerable<TableOrder> FindServantTableOrders(Guid servantId, TimeInterval period);
    }
}
