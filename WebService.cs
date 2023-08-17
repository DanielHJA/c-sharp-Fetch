using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fetch
{
    public class WebService<T> : IWebService<T> 
    {

        private static readonly HttpClient client = new HttpClient();

        public async Task<WebResult<T>> FetchData(string endpoint)
        {
            try
            {
                using HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                T result = JsonConvert.DeserializeObject<T>(json);

                var webResult = new WebResult<T>(result, true);

                return webResult;
            } 
            catch(HttpRequestException ex)
            {
                Console.WriteLine($"{ex.Message}\n");
                return new WebResult<T>(default(T), false, ex.Message);
            }
        }
    }
}