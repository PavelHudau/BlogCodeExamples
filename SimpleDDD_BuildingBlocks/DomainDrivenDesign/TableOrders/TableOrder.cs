using DomainDrivenDesign.Payments;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace DomainDrivenDesign.TableOrders
{
    public class TableOrder
    {
        // Internal collection of items made private.
        private readonly Dictionary<Guid, TableOrderItem> _items =
            new Dictionary<Guid, TableOrderItem>();

        // Status is exposed with only public getter.
        public TableOrderStatus Status { get; private set; } = TableOrderStatus.Open;

        // Property with getter only.
        public decimal TotalBalance => _items.Values.Select(toi => toi.TotalPrice).Sum();

        // Exposing a readonly projection to items collection.
        public IReadOnlyCollection<TableOrderItem> OrderedItems => _items.Values.ToImmutableList();

        /*
        * Below is code that implements domain logic.
        * It also performs all validations to ensure the invariant.
        */

        public void AddOrderItem(MenuItem menuItem)
        {
            _ = menuItem ?? throw new ArgumentNullException(nameof(menuItem));

            if (Status != TableOrderStatus.Open)
            {
                throw new InvalidOperationException("Unable to add order item as it's not open.");
            }

            if (_items.TryGetValue(menuItem.Id, out TableOrderItem orderItem))
            {
                _items[menuItem.Id] = new TableOrderItem(menuItem, orderItem.Count + 1);
            }
            else
            {
                _items.Add(menuItem.Id, new TableOrderItem(menuItem, 1));
            }
        }

        public void RemoveOrderItem(MenuItem menuItem)
        {
            _ = menuItem ?? throw new ArgumentNullException(nameof(menuItem));

            if (Status != TableOrderStatus.Open)
            {
                throw new InvalidOperationException("Unable to remove order item as it's not open.");
            }

            if (_items.TryGetValue(menuItem.Id, out TableOrderItem orderItem))
            {
                if (orderItem.Count <= 1)
                {
                    _items.Remove(menuItem.Id);
                }
                else
                {
                    _items[menuItem.Id] = new TableOrderItem(menuItem, orderItem.Count - 1);
                }
            }
        }

        public void SubmitToKitchen()
        {
            // Implementation details are skipped for the sake of brevity.
            Status = TableOrderStatus.SubmittedToKitchen;
        }

        public void CompleteKitchenPreparation()
        {
            // Implementation details are skipped for the sake of brevity.
            Status = TableOrderStatus.KitchenPrepared;
        }

        public void Served()
        {
            // Implementation details are skipped for the sake of brevity.
            Status = TableOrderStatus.Served;
        }

        public Transaction ProcessPaymentAndCloseOrder(Payment payment)
        {
            if (payment.Currency != Currency.USD)
            {
                throw new UnsupportedCurrencyException(
                    $"{payment.Currency} is not supported for payments.");
            }

            if (TotalBalance > payment.Amount)
            {
                throw new InsufficientPaymentException(
                    "Payment is too small to cover table order balance.");
            }

            var transaction = new Transaction(payment);
            transaction.CompleteTransaction();
            Status = TableOrderStatus.Completed;
            return transaction;
        }
    }
}
