using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class FARM_YEARS
    {
        public int FARM_ID { get; set; }
        public int YEAR { get; set; }
        public int SHARES_REQUESTED { get; set; }
        public string FARM_NAME { get; set; } = null!;
        public DateTime? REDEMPTIONS_SIGNED_OFF { get; set; }
        public int SHARES_REDEEMED { get; set; }
        public int SHARES_ALLOCATED { get; set; }
        public DateTime? DATE_FORM_SIGNED { get; set; }
        public DateTime? DATE_APPLICATION_APPROVED { get; set; }
        public bool PAPER_AGREEMENT_SIGNED { get; set; }
        public bool FINAL_BALANCE_READY { get; set; }

        public virtual FARMS FARM { get; set; } = null!;
    }
}
