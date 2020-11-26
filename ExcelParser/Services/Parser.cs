using System.Collections.Generic;
using System.IO;
using ExcelParser.Models;
using OfficeOpenXml;

namespace ExcelParser.Services {
    public class Parser : IParser {
        public IEnumerable<Employee> ParseEmployeesFromXlsxFile(Stream fileStream) {
            var employees = new List<Employee>();
            using var package = new ExcelPackage(fileStream);
            var sheet = package.Workbook.Worksheets[0];
            int i = 2;
            while (sheet.Cells[i, 3].GetValue<string>() != "") {
                var employee = new Employee {
                    CompanyName = sheet.Cells[i, 1].GetValue<string>(),
                    EmployeeCode = sheet.Cells[i, 2].GetValue<string>(),
                    FirstName = sheet.Cells[i, 3].GetValue<string>(),
                    LastName = sheet.Cells[i, 4].GetValue<string>(),
                    IdCardNumber = sheet.Cells[i, 5].GetValue<string>(),
                    Position = sheet.Cells[i, 6].GetValue<string>(),
                    Department = sheet.Cells[i, 7].GetValue<string>(),
                    CostCentre = sheet.Cells[i, 8].GetValue<string>(),
                    TaxStatus = sheet.Cells[i, 9].GetValue<string>(),
                    PaymentType = sheet.Cells[i, 10].GetValue<string>(),
                    BasicHours = sheet.Cells[i, 11].GetValue<decimal>(),
                    BasicAmount = sheet.Cells[i, 12].GetValue<decimal>(),
                    LeaveHours = sheet.Cells[i, 13].GetValue<decimal>(),
                    LeaveAmount = sheet.Cells[i, 14].GetValue<decimal>(),
                    OvertimeRateHours = sheet.Cells[i, 15].GetValue<decimal>(),
                    OvertimeRateAmount = sheet.Cells[i, 16].GetValue<decimal>(),
                    AdjustmentsPreTax = sheet.Cells[i, 17].GetValue<decimal>(),
                    CashBenefitsTaxable = sheet.Cells[i, 18].GetValue<decimal>(),
                    Gross = sheet.Cells[i, 19].GetValue<decimal>(),
                    Tax = sheet.Cells[i, 20].GetValue<decimal>(),
                    Ssc = sheet.Cells[i, 21].GetValue<decimal>(),
                    SscRetained = sheet.Cells[i, 22].GetValue<decimal>(),
                    CompanySsc = sheet.Cells[i, 23].GetValue<decimal>(),
                    SscContributions = sheet.Cells[i, 24].GetValue<int>(),
                    MatLvFund = sheet.Cells[i, 25].GetValue<decimal>(),
                    AdjustmentsPostTax = sheet.Cells[i, 26].GetValue<decimal>(),
                    CashBenefitsNonTaxable = sheet.Cells[i, 27].GetValue<decimal>(),
                    AdvancedPayment = sheet.Cells[i, 28].GetValue<decimal>(),
                    Net = sheet.Cells[i, 29].GetValue<decimal>(),
                    Cat2 = sheet.Cells[i, 30].GetValue<decimal>(),
                    Cat3 = sheet.Cells[i, 31].GetValue<decimal>(),
                    CarUse = sheet.Cells[i, 32].GetValue<decimal>()
                };
                employees.Add(employee);
                i++;
            }
            return employees;
        }
    }
}
