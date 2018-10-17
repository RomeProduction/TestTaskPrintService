using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReportService.Domain.Services;
using ReportService.Helpers;
using ReportService.Models.Employees;
using ReportService.Models.Reports;

namespace ReportService.Controllers {
	[Route("api/[controller]")]
	public class ReportController : Controller {
		private ConnectionConfig _connectConfig { get; set; }
		private IBuhService _buhService { get; set; }
		public ReportController(IOptions<ConnectionConfig> connectConfig, IBuhService buhService) {
			_connectConfig = connectConfig.Value;
			_buhService = buhService;
		}

		[HttpGet]
		[Route("{year}/{month}")]
		public IActionResult Download(int year, int month) {
			var actions = new List<(Action<Employee, Report>, Employee)>();
			var report = new Report() { Text = MonthNameResolver.MonthName.GetName(year, month) };

			var employess = EmployeeHelper.GetListAllEmployes(_connectConfig.EmployeeConnection);
			if(employess == null) {
				return Json("Error. View in log.");
			}

			foreach(var employee in employess) {
				employee.BuhCode = _buhService.GetCode(employee.Inn).Result;
				employee.Salary = employee.Salary(_connectConfig.SalaryService);
			}

			var grDepartments = employess.GroupBy(x => x.Department);

			decimal sum = 0;
			foreach(var gr in grDepartments) {
				decimal lSum = 0;
				report.WriteDepartment(gr.Key, gr.ToArray(), out lSum);
				sum += lSum;
			}

			report.WriteCompanySum(sum);

			report.Save();
			var file = System.IO.File.ReadAllBytes("D:\\report.txt");
			var response = File(file, "application/octet-stream", "report.txt");
			return response;
		}
	}
}
