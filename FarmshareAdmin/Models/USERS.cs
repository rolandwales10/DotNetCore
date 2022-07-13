using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class USERS
    {
        public int id { get; set; }
        public string? EMAIL_ADDRESS { get; set; }
        public int? FARM_ID { get; set; }
        public bool ADMIN_USER { get; set; }
        public DateTime? LAST_LOGIN { get; set; }
        public string? PASSWORD { get; set; }
        public string? COMMENTS { get; set; }
        public string? LAST_NAME { get; set; }
        public string? FIRST_NAME { get; set; }
        public byte[]? TIMESTAMP { get; set; }
    }
}
