using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorSpa.Shared
{
    public interface IDataAccess
    {
        Task<T> GetJsonAsync<T>(string requestUri);

        Task PostJsonAsync(string requestUri, object content);

        Task<T> PostJsonAsync<T>(string requestUri, object content);

        Task PutJsonAsync(string requestUri, object content);

        Task<T> PutJsonAsync<T>(string requestUri, object content);

        Task SendJsonAsync(HttpMethod method, string requestUri, object content);

        Task<T> SendJsonAsync<T>(HttpMethod method, string requestUri, object content);
    }
}