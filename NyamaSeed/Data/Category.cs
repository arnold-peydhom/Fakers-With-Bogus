using System;
using System.Collections.Generic;

namespace NyamaSeed.Data
{
    public partial class Category
    {
        public Category()
        {
            ExpenseTypes = new HashSet<ExpenseType>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ExpenseType> ExpenseTypes { get; set; }
    }
}
