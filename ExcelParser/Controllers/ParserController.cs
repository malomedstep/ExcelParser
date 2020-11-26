using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExcelParser.Services;
using ExcelParser.ViewModels;
using ExcelParser.Data;
using Microsoft.AspNetCore.Http;

namespace ExcelParser.Controllers {
    [Route("/")]
    public class ParserController : Controller {
        private readonly EmployeesDbContext _context;
        private readonly IParser _parser;
        private readonly ILogger<ParserController> _logger;

        public ParserController(EmployeesDbContext context, IParser parser, ILogger<ParserController> logger) {
            _context = context;
            _parser = parser;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index() {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<IFormFile> files) {
            try {
                foreach (var file in files) {
                    using var stream = file.OpenReadStream();
                    var newEmployees = _parser.ParseEmployeesFromXlsxFile(stream);
                    _context.Employees.AddRange(newEmployees);
                    _logger.LogInformation($"File {file.FileName} was uploaded");
                }
                await _context.SaveChangesAsync();
            } catch (Exception ex) {
                _logger.LogError(ex, "Error occurred during file upload");
            }
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
