namespace ReportService.Domain.Services {
	/// <summary>
	/// Строки подключения
	/// </summary>
	public class ConnectionConfig {
		/// <summary>
		/// Подключение к БД Employee
		/// </summary>
		public string EmployeeConnection { get; set; }
		/// <summary>
		/// Подключение к сервису бухгалтерии
		/// </summary>
		public string BuhServiceConnection { get; set; }
		/// <summary>
		/// Подключение к сервису для получения з/п сотрудника
		/// </summary>
		public string SalaryService { get; set; }
	}
}
