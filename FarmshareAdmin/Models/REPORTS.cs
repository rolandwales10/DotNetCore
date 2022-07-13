using System;
using System.Collections.Generic;

namespace FarmshareAdmin.Models
{
    public partial class REPORTS
    {
        public int id { get; set; }
        public string reportName { get; set; } = null!;
        public string? reportComments { get; set; }
        public string reportingSoftware { get; set; } = null!;
        public string? parmFarmName { get; set; }
        public string? parmId { get; set; }
        public string? parmIdLabel { get; set; }
        public string? parmDate { get; set; }
        public string? parmDateLabel { get; set; }
        public string? parmYear { get; set; }
        public string? parmYearLabel { get; set; }
    }
}
