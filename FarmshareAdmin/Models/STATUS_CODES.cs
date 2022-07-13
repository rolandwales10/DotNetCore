using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class STATUS_CODES
    {
        public string STATUS { get; set; } = null!;
        public bool REDEEMABLE_STATUS { get; set; }
        public string DESCRIPTION { get; set; } = null!;
    }
}
