using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class FARMS
    {
        public FARMS()
        {
            CITIZEN_AGREEMENTS = new HashSet<CITIZEN_AGREEMENTS>();
            FARM_CROPS = new HashSet<FARM_CROPS>();
            FARM_PAYMENTS = new HashSet<FARM_PAYMENTS>();
            FARM_PRODUCE_PICKUP_LOCATIONS = new HashSet<FARM_PRODUCE_PICKUP_LOCATIONS>();
            FARM_PRODUCT_PURCHASES = new HashSet<FARM_PRODUCT_PURCHASES>();
            FARM_REFERENCES = new HashSet<FARM_REFERENCES>();
            FARM_YEARS = new HashSet<FARM_YEARS>();
        }

        public int FARM_ID { get; set; }
        public string FARM_NAME { get; set; } = null!;
        public int YEAR { get; set; }
        public string STATUS { get; set; } = null!;
        public string? FARM_CONTACT_FIRST { get; set; }
        public string? FARM_CONTACT_LAST { get; set; }
        public string? FARM_OWNER_FIRST { get; set; }
        public string? FARM_OWNER_LAST { get; set; }
        public string? MAIL_ADDRESS1 { get; set; }
        public string? MAIL_ADDRESS2 { get; set; }
        public string? CITY { get; set; }
        public string? ZIP { get; set; }
        public string? STATE { get; set; }
        public string? FARM_LOCATION { get; set; }
        public string? HOME_PHONE { get; set; }
        public string? CELL_PHONE { get; set; }
        public string? FAX { get; set; }
        public string? COMMENTS { get; set; }
        public string? VENDOR_NUMBER { get; set; }
        public DateTime? VENDOR_INFO_UPDATED_DATE { get; set; }
        public bool VENDOR_FORM_RETURNED { get; set; }
        public DateTime? NAME_ADDRESS_CHANGE_DATE { get; set; }
        public string? LAST_MODIFIED_BY { get; set; }
        public DateTime? LAST_MODIFIED_DATE { get; set; }
        public bool SENIOR_SELECTS { get; set; }
        public bool FARMER_SELECTS { get; set; }
        public int INDIVIDUAL_DELIVER_MILE_RADIUS { get; set; }
        public int GROUP_DELIVER_MILE_RADIUS { get; set; }
        public int MIN_NBR_FOR_GROUP_DELIVER { get; set; }
        public string SEASON_BEGINS { get; set; } = null!;
        public string SEASON_ENDS { get; set; } = null!;
        public decimal ACRES_IN_VARIETY_OF_MIXED_VEGES { get; set; }
        public decimal ACRES_IN_SMALL_FRUIT_CROPS { get; set; }
        public bool FORM_COMPLETE { get; set; }
        public bool FARM_STAND_MARKETING { get; set; }
        public bool FARMERS_MARKET_MARKETING { get; set; }
        public bool CSA_MARKETING { get; set; }
        public bool FMNP_PARTICIPATION { get; set; }
        public bool SNAP_PARTICIPATION { get; set; }
        public bool MINIMUM_OFFER_CONFIRM { get; set; }
        public int FIRST_YEAR { get; set; }
        public DateTime? LAST_INSPECTION_DATE { get; set; }
        public string? ADMIN_COMMENTS { get; set; }

        public virtual ICollection<CITIZEN_AGREEMENTS> CITIZEN_AGREEMENTS { get; set; }
        public virtual ICollection<FARM_CROPS> FARM_CROPS { get; set; }
        public virtual ICollection<FARM_PAYMENTS> FARM_PAYMENTS { get; set; }
        public virtual ICollection<FARM_PRODUCE_PICKUP_LOCATIONS> FARM_PRODUCE_PICKUP_LOCATIONS { get; set; }
        public virtual ICollection<FARM_PRODUCT_PURCHASES> FARM_PRODUCT_PURCHASES { get; set; }
        public virtual ICollection<FARM_REFERENCES> FARM_REFERENCES { get; set; }
        public virtual ICollection<FARM_YEARS> FARM_YEARS { get; set; }
    }
}
