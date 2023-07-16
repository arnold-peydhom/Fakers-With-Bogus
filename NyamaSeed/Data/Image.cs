using System;
using System.Collections.Generic;

namespace NyamaSeed.Data
{
    public partial class Image
    {
        public Image()
        {
            Shops = new HashSet<Shop>();
        }

        public int ImageId { get; set; }
        public byte[] Content { get; set; } = null!;
        public string Extension { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Shop> Shops { get; set; }
    }
}
