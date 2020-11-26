namespace ExcelParser.Models {
    public class Employee {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCardNumber { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string CostCentre { get; set; }
        public string TaxStatus { get; set; }
        public string PaymentType { get; set; }  
        public decimal BasicHours { get; set; }  
        public decimal BasicAmount { get; set; }  
        public decimal LeaveHours { get; set; }  
        public decimal LeaveAmount { get; set; }
        public decimal OvertimeRateHours { get; set; }
        public decimal OvertimeRateAmount { get; set; }
        public decimal AdjustmentsPreTax { get; set; }
        public decimal CashBenefitsTaxable { get; set; }
        public decimal Gross { get; set; }
        public decimal Tax { get; set; }
        public decimal Ssc { get; set; }
        public decimal SscRetained { get; set; }
        public decimal CompanySsc { get; set; }
        public int SscContributions { get; set; }
        public decimal MatLvFund { get; set; }
        public decimal AdjustmentsPostTax { get; set; }
        public decimal CashBenefitsNonTaxable { get; set; }
        public decimal AdvancedPayment { get; set; }
        public decimal Net { get; set; }
        public decimal Cat2 { get; set; }
        public decimal Cat3 { get; set; }
        public decimal CarUse { get; set; }
    }
}
