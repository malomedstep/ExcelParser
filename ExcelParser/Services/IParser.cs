using System.Collections.Generic;
using System.IO;
using ExcelParser.Models;

namespace ExcelParser.Services {
    public interface IParser {
        IEnumerable<Employee> ParseEmployeesFromXlsxFile(Stream fileStream);
    }
}