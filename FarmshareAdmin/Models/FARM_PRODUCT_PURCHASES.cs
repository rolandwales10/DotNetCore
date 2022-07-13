using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class FARM_PRODUCT_PURCHASES
    {
        public int id { get; set; }
        public int FARM_ID { get; set; }
        public string PRODUCE { get; set; } = null!;
        public string FROM_FARM { get; set; } = null!;

        public virtual FARMS FARM { get; set; } = null!;
    }
}
