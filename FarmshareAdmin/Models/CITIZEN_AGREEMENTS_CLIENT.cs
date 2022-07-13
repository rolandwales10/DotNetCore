using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class CITIZEN_AGREEMENTS_CLIENT
    {
        public int ID { get; set; }
        public int? CITIZEN_AGREEMENT_ID { get; set; }
        public int? FARM_ID { get; set; }
        public int? CLIENT_ID { get; set; }
        public int YEAR { get; set; }
        public string STATUS { get; set; } = null!;
        public string? WHO_SELECTS_PRODUCE { get; set; }
        public string? DELIVERY_LOCATION_TYPE { get; set; }
        public string? DELIVERY_LOCATION { get; set; }
        public string? DELIVERY_DATE { get; set; }
        public string? DELIVERY_TIME { get; set; }
        public string? FIRST_NAME { get; set; }
        public string? LAST_NAME { get; set; }
        public string? ADDRESS1 { get; set; }
        public string? ADDRESS2 { get; set; }
        public string? CITY { get; set; }
        public string? STATE { get; set; }
        public string? ZIP { get; set; }
        public string? PHONE { get; set; }
        public string? PHONE2 { get; set; }
        public string? EMAIL { get; set; }
        public string? ADMIN_LAST_MOD_DATE { get; set; }
        public string? COMMENTS { get; set; }
        public string? BIRTH_DATE { get; set; }
        public string? FARMER_LAST_MOD_DATE { get; set; }
        public string? TERMINATION_REASON { get; set; }
        public string? DATE_INVOICED { get; set; }
        public string? REASON_FULL_VALUE_NOT_USED { get; set; }
        public bool RACE_WHITE { get; set; }
        public bool RACE_BLACK { get; set; }
        public bool RACE_HAWAIIAN { get; set; }
        public bool RACE_INDIAN { get; set; }
        public bool RACE_ASIAN { get; set; }
        public string? HISPANIC_OR_LATINO { get; set; }
        public string? SIGNOFF_METHOD { get; set; }
        public string? DATE_ENROLLED { get; set; }
        public bool DISABLED_ADULT { get; set; }
    }
}
