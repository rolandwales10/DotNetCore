namespace FarmshareAdmin.Data
{
    public class FarmAllocation
    {
        public class Vm_Farm_Allocation
        {
            public int FarmId { get; set; }
            public string FarmName { get; set; }
            public string Note { get; set; }
            public string Status { get; set; }
            public decimal PrevYearSharesRequested { get; set; }
            public decimal PrevYearSharesAlloc { get; set; }
            public decimal PrevYearSharesRedeemed { get; set; }
            public decimal PrevYearSharesPaid { get; set; }
            public decimal CurYearSharesInvoiced { get; set; }
            public decimal CurYearSharesNotInvoiced { get; set; }
            public int CurYearSharesRequested { get; set; }
            public int CurYearSharesAlloc { get; set; }
            public int SharesAdjustment { get; set; }
            public int SharesNewAlloc { get; set; }
            public bool Approved { get; set; }
        }

        public class Vm_Farm_Allocations
        {
            public Vm_Farm_Allocations()
            {
                items = new List<Vm_Farm_Allocation>();
                messages = new List<string>();
            }

            public List<string> messages { get; set; }
            public List<Vm_Farm_Allocation> items { get; set; }
            public int TotalFarms { get; set; }
            public decimal TotalCurrentAllocations { get; set; }
            public decimal TotalAdjustments { get; set; }
            public decimal TotalNewAllocations { get; set; }
            public decimal FirstFundingAllocation { get; set; }
            public decimal SecondFundingAllocation { get; set; }
            public int ShareValue { get; set; }
        }

    }
}
