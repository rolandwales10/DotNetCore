using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class CITIZEN_AGREEMENT_YEARS
    {
        public int CITIZEN_AGREEMENT_ID { get; set; }
        public int YEAR { get; set; }
        public string STATUS { get; set; } = null!;
        public string? REASON_FULL_VALUE_NOT_USED { get; set; }
        public string? SIGNOFF_METHOD { get; set; }
        public DateTime? DATE_ENROLLED { get; set; }

        public virtual CITIZEN_AGREEMENTS CITIZEN_AGREEMENT { get; set; } = null!;
    }
}
