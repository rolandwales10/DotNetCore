using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class MESSAGE_LOG
    {
        public string USERID { get; set; } = null!;
        public DateTime CREATE_TIME { get; set; }
        public string LOG_MESSAGE { get; set; } = null!;
    }
}
