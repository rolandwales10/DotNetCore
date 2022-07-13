using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class EDIT_ACTIVITY
    {
        public int ID { get; set; }
        public int CITIZEN_AGREEMENT_ID { get; set; }
        public string TABLE { get; set; } = null!;
        public string ACTIVITY { get; set; } = null!;
        public DateTime DATE { get; set; }
        public int USERID { get; set; }
    }
}
