using System;
using System.Collections.Generic;

namespace NyamaSeed.Data
{
    public partial class District
    {
        public District()
        {
            Shops = new HashSet<Shop>();
        }

        public int DistrictId { get; set; }
        public string Name { get; set; } = null!;
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual ICollection<Shop> Shops { get; set; }
    }
}
