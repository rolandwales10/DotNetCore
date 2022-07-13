using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class FIELD_VALUES
    {
        public int id { get; set; }
        public string FIELD_ID { get; set; } = null!;
        public decimal? FIELD_AMOUNT { get; set; }
        public string? FIELD_VALUE { get; set; }
        public string? COMMENTS { get; set; }
    }
}
