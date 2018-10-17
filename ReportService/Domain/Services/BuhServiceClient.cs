using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace ReportService.Domain.Services {
	public interface IBuhService {
		Task<string> GetCode(string inn);
	}

	public class BuhServiceClient : IBuhService {
		private readonly HttpClient _client;

		public BuhServiceClient(IOptions<ConnectionConfig> connectionConfig) {
			var httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(connectionConfig.Value.BuhServiceConnection);
			_client = httpClient;
		}

		public async Task<string> GetCode(string inn) {
			return await _client.GetStringAsync(_client.BaseAddress + inn);
		}
	}
}
