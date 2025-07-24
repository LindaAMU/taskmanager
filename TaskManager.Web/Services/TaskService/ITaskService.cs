using TaskManager.Web.Models;
using TaskManager.Web.Models.Tasks;

namespace TaskManager.Web.Services.TaskService
{
    public interface ITaskService
    {
        public Task<string> Create(TaskModel model);

        public Task<List<TaskModel>> GetAll();

        public Task<List<TaskModel>> GetFilter(int filter);

        public Task<string> ChangeStatus(int status, int id);

        public Task<string> Delete(int id);
    }
}
