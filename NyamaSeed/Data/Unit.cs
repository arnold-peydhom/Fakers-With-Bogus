using System;
using System.Collections.Generic;

namespace NyamaSeed.Data
{
    public partial class Unit
    {
        public Unit()
        {
            Expenses = new HashSet<Expense>();
        }

        public int UnitId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
