using System.Net;
using System.Net.Http.Json;

namespace AirMark.Web
{
    public class AirMarkClient
    {
        private readonly HttpClient _httpClient;

        public AirMarkClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpStatusCode, string?> GetAirMarkAsync()
        {
            if (_httpClient.BaseAddress is null)
            {
                return (HttpStatusCode.OK, null);
            }

            var response = await _httpClient.GetAsync("world");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;
            var airMarkResponse = JsonConvert.DeserializeObject<AirMarkResponse>(content);

            return  (statusCode, content);
        }
    }
}
