using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class FARM_PRODUCE_PICKUP_LOCATIONS
    {
        public int ID { get; set; }
        public int FARM_ID { get; set; }
        public string LOCATION_TYPE { get; set; } = null!;
        public string LOCATION_NAME { get; set; } = null!;
        public string DAYS { get; set; } = null!;
        public string TIMES { get; set; } = null!;
        public string? ADDRESS { get; set; }
        public string? CITY { get; set; }
        public string? STATE { get; set; }
        public string? ZIP { get; set; }

        public virtual FARMS FARM { get; set; } = null!;
    }
}
