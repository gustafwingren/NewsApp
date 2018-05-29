using System.Threading.Tasks;

namespace NewsApp.Services.Authentication
{
    public interface IBrowserCookiesService
    {
        Task ClearCookiesAsync();
    }
}
