namespace ReportService.Models.Employees {
	/// <summary>
	/// Сотрудник
	/// </summary>
	public class Employee
    {
		/// <summary>
		/// Имя
		/// </summary>
        public string Name { get; set; }
		/// <summary>
		/// Подразделение
		/// </summary>
        public string Department { get; set; }
		/// <summary>
		/// ИНН
		/// </summary>
        public string  Inn { get; set; }
		/// <summary>
		/// ЗП
		/// </summary>
        public decimal? Salary { get; set; }
		/// <summary>
		/// Код бухгалтерии
		/// </summary>
        public string BuhCode { get; set; }
    }
}
