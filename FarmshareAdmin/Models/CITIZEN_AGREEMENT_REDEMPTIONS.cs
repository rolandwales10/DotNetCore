using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class CITIZEN_AGREEMENT_REDEMPTIONS
    {
        public int CITIZEN_AGREEMENT_ID { get; set; }
        public DateTime DATE_REDEEMED { get; set; }
        public decimal AMOUNT { get; set; }
        public int? FARM_ID { get; set; }
        public int YEAR { get; set; }

        public virtual CITIZEN_AGREEMENTS CITIZEN_AGREEMENT { get; set; } = null!;
    }
}
