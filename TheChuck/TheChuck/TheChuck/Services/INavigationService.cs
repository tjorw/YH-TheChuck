using System.Threading.Tasks;

namespace TheChuck.Services
{
    public interface INavigationService
    {
        Task GoBack();
        Task GoToSearch();
        Task GoToCategory(string category);
    }
}
