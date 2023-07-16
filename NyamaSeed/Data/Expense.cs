using System;
using System.Collections.Generic;

namespace NyamaSeed.Data
{
    public partial class Expense
    {
        public int ExpenseId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateOfExpense { get; set; }
        public int UnitId { get; set; }
        public int ExpenseTypeId { get; set; }

        public virtual ExpenseType ExpenseType { get; set; } = null!;
        public virtual Unit Unit { get; set; } = null!;
    }
}
