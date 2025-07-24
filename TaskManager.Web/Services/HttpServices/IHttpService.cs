using System.Text;
using System.Text.Json;

namespace TaskManager.Web.Services.HttpServices
{
    public interface IHttpService
    {
        public Task<T> Get<T>(string uri);
        public Task<T> Post<T>(string uri, object value);
        public Task<T> Patch<T>(string uri, object value);
        public Task<T> Delete<T>(string uri);
    }
}
