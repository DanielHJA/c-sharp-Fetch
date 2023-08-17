using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fetch
{
    public class WebService : IWebService 
    {

        private static readonly HttpClient client = new HttpClient();

        public async Task<Result> FetchData(string endpoint)
        {
            try
            {
                using HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<Result>(json);

                return result;
            } 
            catch(HttpRequestException ex)
            {
                Console.WriteLine($"{ex.Message}\n");
                return new Result();
            }
        }
    }
}