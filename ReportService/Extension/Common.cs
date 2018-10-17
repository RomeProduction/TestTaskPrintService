using Newtonsoft.Json;
using ReportService.Models.Employees;
using System.IO;
using System.Net;

namespace ReportService {
	/// <summary>
	/// Методы расширений
	/// </summary>
	public static class EmployeeCommonMethods
    {
		/// <summary>
		/// Получаем зарплату для сотрудника
		/// </summary>
		/// <param name="connString">Строка подключения</param>
		/// <param name="employee">Сотрудник</param>
		/// <returns></returns>
        public static decimal? Salary(this Employee employee, string connString)
        {
			if(employee == null) {
				return null;
			}
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(connString + employee.Inn);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new { employee.BuhCode });
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var reader = new System.IO.StreamReader(httpResponse.GetResponseStream(), true);
            string responseText = reader.ReadToEnd();
			decimal sum = 0;
			if(decimal.TryParse(responseText, out sum)){
				return sum;
			}
            return null;
        }

    }
}
