using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class CITIZEN_AGREEMENTS
    {
        public CITIZEN_AGREEMENTS()
        {
            CITIZEN_AGREEMENT_REDEMPTIONS = new HashSet<CITIZEN_AGREEMENT_REDEMPTIONS>();
            CITIZEN_AGREEMENT_YEARS = new HashSet<CITIZEN_AGREEMENT_YEARS>();
            FARM_PAYMENTS = new HashSet<FARM_PAYMENTS>();
        }

        public int CITIZEN_AGREEMENT_ID { get; set; }
        public int? FARM_ID { get; set; }
        public int YEAR { get; set; }
        public string WHO_SELECTS_PRODUCE { get; set; } = null!;
        public string? DELIVERY_LOCATION_TYPE { get; set; }
        public string? DELIVERY_LOCATION { get; set; }
        public string? DELIVERY_DATE { get; set; }
        public string? DELIVERY_TIME { get; set; }
        public string FIRST_NAME { get; set; } = null!;
        public string LAST_NAME { get; set; } = null!;
        public string? ADDRESS1 { get; set; }
        public string? ADDRESS2 { get; set; }
        public string? CITY { get; set; }
        public string? STATE { get; set; }
        public string? ZIP { get; set; }
        public string? PHONE { get; set; }
        public string? PHONE2 { get; set; }
        public string? EMAIL { get; set; }
        public DateTime? ADMIN_LAST_MOD_DATE { get; set; }
        public string? COMMENTS { get; set; }
        public DateTime? BIRTH_DATE { get; set; }
        public DateTime? FARMER_LAST_MOD_DATE { get; set; }
        public string? TERMINATION_REASON { get; set; }
        public bool RACE_WHITE { get; set; }
        public bool RACE_BLACK { get; set; }
        public bool RACE_HAWAIIAN { get; set; }
        public bool RACE_INDIAN { get; set; }
        public bool RACE_ASIAN { get; set; }
        public bool HISPANIC_OR_LATINO { get; set; }
        public bool DISABLED_ADULT { get; set; }

        public virtual FARMS? FARM { get; set; }
        public virtual ICollection<CITIZEN_AGREEMENT_REDEMPTIONS> CITIZEN_AGREEMENT_REDEMPTIONS { get; set; }
        public virtual ICollection<CITIZEN_AGREEMENT_YEARS> CITIZEN_AGREEMENT_YEARS { get; set; }
        public virtual ICollection<FARM_PAYMENTS> FARM_PAYMENTS { get; set; }
    }
}
