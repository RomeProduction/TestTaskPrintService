using System;
using System.Collections.Generic;
using System.Text;
using ReportService.Models.Employees;

namespace ReportService.Models.Reports {
	public class Report
    {
        public string Text { get; set; }

		/// <summary>
		/// Записать информацию по отделу
		/// </summary>
		/// <param name="depName">Наименование отдела</param>
		/// <param name="employess">Сотрудники отдела</param>
		public void WriteDepartment(string depName, IEnumerable<Employee> employess, out decimal comSum) {
			var sb = new StringBuilder();

			sb.Append(Environment.NewLine);
			sb.Append("--------------------------------------------");
			sb.Append(Environment.NewLine);
			sb.Append(depName + Environment.NewLine);
			decimal sum = 0;
			foreach(var empl in employess) {
				sum += (empl.Salary.HasValue ? empl.Salary.Value : Decimal.Zero);
				sb.Append(empl.Name + " " + 
					(empl.Salary.HasValue ? empl.Salary.Value.ToString("0") + "р" : " - ")
					 + Environment.NewLine);
			}
			comSum = sum;

			sb.Append("Всего по отделу" + " " + sum + Environment.NewLine);

			Text += sb.ToString();
		}

		/// <summary>
		/// Запись результирующей суммы по предприятию
		/// </summary>
		/// <param name="sum"></param>
		public void WriteCompanySum(decimal sum) {
			var sb = new StringBuilder();
			sb.Append(Environment.NewLine);
			sb.Append("--------------------------------------------");
			sb.Append(Environment.NewLine);
			sb.Append("Всего по предприятию " + sum.ToString("0"));

			Text += sb.ToString();
		}

        public void Save()
        {
            System.IO.File.WriteAllText("D:\\report.txt", Text);
        }
    }
}
