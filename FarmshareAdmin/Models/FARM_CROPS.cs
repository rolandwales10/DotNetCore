using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class FARM_CROPS
    {
        public int id { get; set; }
        public int FARM_ID { get; set; }
        public int YEAR { get; set; }
        public string PRODUCE { get; set; } = null!;
        public decimal? ACRES { get; set; }
        public bool SEASON_EARLY { get; set; }
        public bool SEASON_MID { get; set; }
        public bool SEASON_FALL { get; set; }

        public virtual FARMS FARM { get; set; } = null!;
    }
}
