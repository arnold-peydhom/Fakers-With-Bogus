using System;
using System.Collections.Generic;

namespace NyamaSeed.Data
{
    public partial class ExpenseType
    {
        public ExpenseType()
        {
            Expenses = new HashSet<Expense>();
        }

        public int ExpenseTypeId { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
