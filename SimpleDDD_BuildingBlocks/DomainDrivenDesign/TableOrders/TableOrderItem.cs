using DomainDrivenDesign.Payments;
using System;

namespace DomainDrivenDesign.TableOrders
{
    public struct TableOrderItem
    {
        public TableOrderItem(MenuItem menuItem, int count)
        {
            _ = menuItem ?? throw new ArgumentNullException(nameof(menuItem));
            PricePerOne = menuItem.Price;
            Count = count;
        }

        public decimal PricePerOne { get; private set; }

        public int Count { get; private set; }

        // C# simplified syntax for a property with a getter only.
        public decimal TotalPrice => PricePerOne * Count;

        /*
        * Equality operators and methods overrides below.
        */

        public override bool Equals(object obj)
        {
            return obj is TableOrderItem item &&
                    PricePerOne == item.PricePerOne &&
                    Count == item.Count;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PricePerOne, Count);
        }

        public static bool operator ==(TableOrderItem a, TableOrderItem b) =>
            a.PricePerOne == b.PricePerOne &&
            a.Count == b.Count;

        public static bool operator !=(TableOrderItem a, TableOrderItem b) => !(a == b);
    }
}