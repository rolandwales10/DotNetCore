using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class FARM_PAYMENTS
    {
        public int ID { get; set; }
        public int FARM_ID { get; set; }
        public int? CITIZEN_AGREEMENT_ID { get; set; }
        public string PAYMENT_TYPE { get; set; } = null!;
        public DateTime DATE_ENTERED { get; set; }
        public decimal AMOUNT { get; set; }
        public DateTime? DATE_INVOICED { get; set; }
        public DateTime? DATE_RECEIVED { get; set; }
        public int? USER_ID { get; set; }
        public int YEAR { get; set; }

        public virtual CITIZEN_AGREEMENTS? CITIZEN_AGREEMENT { get; set; }
        public virtual FARMS FARM { get; set; } = null!;
    }
}
