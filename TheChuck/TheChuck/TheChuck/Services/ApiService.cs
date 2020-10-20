using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TheChuck.Services
{

    public class SearchResult<T>
    {
        public int total { get; set; }
        public T[] result { get; set; }
    }

    public class Joke
    {
        public string icon_url { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public string value { get; set; }
    }

    public class ApiService : IApiService
    {
        public async Task<string[]> GetCategories()
        {
            var data = await get("https://api.chucknorris.io/jokes/categories");
            return JsonConvert.DeserializeObject<string[]>(data);
        }

        public async Task<Joke> GetRandom()
        {
            var data = await get("https://api.chucknorris.io/jokes/random");
            return JsonConvert.DeserializeObject<Joke>(data);
        }

        public async Task<Joke> GetRandomByCategory(string category)
        {
            var data = await get($"https://api.chucknorris.io/jokes/random?category={category}");
            return JsonConvert.DeserializeObject<Joke>(data);
        }

        public async Task<SearchResult<Joke>> Search(string query)
        {
            var data = await get($"https://api.chucknorris.io/jokes/search?query={query}");
            return JsonConvert.DeserializeObject<SearchResult<Joke>>(data);
        }


        private async Task<string> get(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return "";

        }
    }
}
