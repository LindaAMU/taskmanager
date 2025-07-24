using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities.TaskManager;

namespace TaskManager.Domain.Context
{
    public class TaskManagerContext(DbContextOptions<TaskManagerContext> opts) : DbContext(opts)
    {
        public DbSet<TaskItems> TaskItems => Set<TaskItems>();
    }
}
