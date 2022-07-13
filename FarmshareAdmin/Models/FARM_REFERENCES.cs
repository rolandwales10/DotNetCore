using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class FARM_REFERENCES
    {
        public int id { get; set; }
        public int FARM_ID { get; set; }
        public string ORGANIZATION { get; set; } = null!;
        public string CONTACT_PERSON { get; set; } = null!;
        public string PHONE { get; set; } = null!;

        public virtual FARMS FARM { get; set; } = null!;
    }
}
