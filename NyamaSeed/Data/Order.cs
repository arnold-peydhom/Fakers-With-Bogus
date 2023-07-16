using System;
using System.Collections.Generic;

namespace NyamaSeed.Data
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime CreatingDate { get; set; }
        public bool IsPayLater { get; set; }
        public int QuantityOfBags { get; set; }
        public DateTime? PayementDate { get; set; }
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; } = null!;
    }
}
