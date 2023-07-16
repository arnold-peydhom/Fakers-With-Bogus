using System;
using System.Collections.Generic;

namespace NyamaSeed.Data
{
    public partial class Shop
    {
        public Shop()
        {
            Orders = new HashSet<Order>();
        }

        public int ShopId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsProspection { get; set; }
        public string FirstPhone { get; set; } = null!;
        public bool? IsWhatsappFirstPhone { get; set; }
        public string? GpsLongigtude { get; set; }
        public string? GpsLatitude { get; set; }
        public string? SecondPhone { get; set; }
        public bool? IsWhatsappSecondPhone { get; set; }
        public DateTime CreatingDate { get; set; }
        public DateTime JoiningDate { get; set; }
        public int? ImageId { get; set; }
        public int DistrictId { get; set; }

        public virtual District District { get; set; } = null!;
        public virtual Image? Image { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
