using System;
using System.Collections.Generic;

namespace NyamaSeed.Data
{
    public partial class City
    {
        public City()
        {
            Districts = new HashSet<District>();
        }

        public int CityId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<District> Districts { get; set; }
    }
}
