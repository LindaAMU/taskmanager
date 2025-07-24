using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models;
using TaskManager.API.Models.Tasks;
using TaskManager.Domain.Context;
using TaskManager.Domain.Entities.TaskManager;

namespace TaskManager.API.Controllers.TaskControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly TaskManagerContext _taskManagerContext;

        public TaskController(TaskManagerContext taskManagerContext)
        {
            this._taskManagerContext = taskManagerContext;
        }

        [HttpPost("[action]")]
        [EnableCors("PolicyCors")]
        public IActionResult Create([FromBody] TaskRequest request)
        {
            StandardResponse response = new();
            try
            {   /* Valida el modelo */
                if (String.IsNullOrEmpty(request.Title) || String.IsNullOrEmpty(request.Description))
                {
                    response.Success = false;
                    response.Message = "No title or description specified";
                    response.Code = 601;
                    return Ok(response);
                }

                TaskItems newItem = new() 
                {
                    Description = request.Description,
                    Title = request.Title,
                    Status = request.Status,
                };

                this._taskManagerContext.Add(newItem);
                this._taskManagerContext.SaveChanges();

                response.Success = true;
                response.Message = "The task was added successfully";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("[action]")]
        [EnableCors("PolicyCors")]
        public IActionResult GetAll()
        {
            TaskListResponse response = new();

            try
            {
                var taskList = this._taskManagerContext.TaskItems.ToList();
                if (taskList.Count == 0)
                {
                    response.Success = false;
                    response.Message = "No tasks found";
                    response.Code = 602;
                    return Ok(response);
                }
                response.Success = true;
                response.Message = $"{taskList.Count} tasks were found";
                response.Tasks = taskList;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("[action]")]
        [EnableCors("PolicyCors")]
        public IActionResult GetFilter([FromQuery]int filter)
        {
            TaskListResponse response = new();
            try
            {
                var taskList = this._taskManagerContext.TaskItems.Where(t => t.Status == filter).ToList();
                if (taskList.Count == 0)
                {
                    response.Success = false;
                    response.Message = "No tasks found";
                    response.Code = 602;
                    return Ok(response);
                }
                response.Success = true;
                response.Message = $"{taskList.Count} tasks were found";
                response.Tasks = taskList;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpPatch("[action]")]        
        [EnableCors("PolicyCors")]
        public IActionResult ChangeStatus ([FromQuery] int status, int id)
        {
            StandardResponse response = new();
            try
            {
                var task = this._taskManagerContext.TaskItems.FirstOrDefault(t => t.Id == id);
                if (task == null)
                {
                    response.Success = false;
                    response.Message = "No tasks found";
                    response.Code = 602;
                    return Ok(response);
                }

                task.Status = status; //TODO Crear validación de status

                this._taskManagerContext.SaveChanges();
                response.Success = true;
                response.Message = "The task status was updated successfully";

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("[action]")]
        [EnableCors("PolicyCors")]
        public IActionResult Delete([FromQuery] int id)
        {
            StandardResponse response = new();
            try
            {
                var task = this._taskManagerContext.TaskItems.FirstOrDefault(t => t.Id == id);
                if (task == null)
                {
                    response.Success = false;
                    response.Message = "No tasks found";
                    response.Code = 602;
                    return Ok(response);
                }
                this._taskManagerContext.Remove(task);
                this._taskManagerContext.SaveChanges();

                response.Success = true;
                response.Message = "The task was deleted successfully";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return Ok(response);
        }
    }
}
