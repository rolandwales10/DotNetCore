using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class LOCATIONS
    {
        public int id { get; set; }
        public string LOCATION { get; set; } = null!;
        public string ZIPCODE { get; set; } = null!;
        public string? COUNTY { get; set; }
    }
}
