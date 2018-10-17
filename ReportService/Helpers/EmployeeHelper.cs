using System;
using System.Collections.Generic;
using Npgsql;
using ReportService.Models.Employees;

namespace ReportService.Helpers {
	/// <summary>
	/// Хелпер для работы с пользователями
	/// </summary>
	public static class EmployeeHelper {
		/// <summary>
		/// Получить список всех сотрудников
		/// </summary>
		/// <param name="connString">Строка подключения</param>
		/// <returns></returns>
		public static IList<Employee> GetListAllEmployes(string connString) {
			List<Employee> employess = null;
			try {
				
				var conn = new NpgsqlConnection(connString);
				conn.Open();
				var cmd = new NpgsqlCommand("SELECT e.name, e.inn, d.name from emps e left join deps d on e.departmentid = d.id"
					+ " where d.active = true", conn);
				var reader1 = cmd.ExecuteReader();

				employess = new List<Employee>();

				while(reader1.Read()) {
					var emp = new Employee() { Name = reader1.GetString(0), Inn = reader1.GetString(1), Department = reader1.GetString(2) };
					employess.Add(emp);
				}

				return employess;
			} catch(Exception ex) {
				//Log error
				return employess;
			}
		}
	}
}
