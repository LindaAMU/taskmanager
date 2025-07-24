using System.Reflection;
using TaskManager.Web.Models;
using TaskManager.Web.Models.Tasks;
using TaskManager.Web.Services.HttpServices;

namespace TaskManager.Web.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpService _httpService;

        public TaskService(IConfiguration configuration, IHttpService httpService)
        {
            _configuration = configuration;
            _httpService = httpService;
        }

        public async Task<string> Create(TaskModel model)
        {
            try
            {
                StandardResponce responce = await this._httpService.Post<StandardResponce>(this._configuration["API:Create"], model);

                if (responce != null)
                {
                    return responce.Message;
                }
                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TaskModel>> GetAll()
        {
            try
            {
                TaskListResponse responce = await this._httpService.Get<TaskListResponse>(this._configuration["API:GetAll"]);
                if (responce != null)
                {
                    return responce.Tasks;
                }
                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TaskModel>> GetFilter(int filter)
        {
            try
            {
                TaskListResponse responce = await this._httpService.Get<TaskListResponse>(String.Format(this._configuration["API:GetFilter"], filter));
                if (responce != null)
                {
                    return responce.Tasks;
                }
                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> ChangeStatus(int status, int id)
        {
            try
            {
                StandardResponce responce = await this._httpService.Patch<StandardResponce>(String.Format(this._configuration["API:ChangeStatus"], status, id), null);
                if (responce != null)
                {
                    return responce.Message;
                }
                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                StandardResponce responce = await this._httpService.Delete<StandardResponce>(String.Format(this._configuration["API:Delete"], id));
                if (responce != null)
                {
                    return responce.Message;
                }
                return default;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
