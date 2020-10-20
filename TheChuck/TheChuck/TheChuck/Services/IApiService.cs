using System.Threading.Tasks;

namespace TheChuck.Services
{
    public interface IApiService
    {
        Task<Joke> GetRandom();
        Task<Joke> GetRandomByCategory(string category);
        Task<string[]> GetCategories();
        Task<SearchResult<Joke>> Search(string query);
    }
}
