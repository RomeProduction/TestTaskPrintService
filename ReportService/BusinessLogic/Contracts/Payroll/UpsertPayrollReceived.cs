using System;

namespace BusinessLogic.Contracts.Payroll {
	public class UpsertPayrollReceived
    {
        public bool IsNew { get; set; }
        public PayrollInLayer Payroll { get; set; }
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
    }
}
