using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerZUwierzytelnieniem.Data;
using TaskManagerZUwierzytelnieniem.Models;

namespace TaskManagerZUwierzytelnieniem.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public TaskModel Get(int taskId)
            => _context.Table.SingleOrDefault(x => x.TaskId == taskId);
        public IQueryable<TaskModel> GetAllActive()
            => _context.Table.Where(x => !x.Done);

        public void Add(TaskModel task)
        {
            _context.Table.Add(task);
            _context.SaveChanges();
        }

        public void Update(int taskId, TaskModel task)
        {
            var result = _context.Table.SingleOrDefault(x => x.TaskId == taskId);
            if (result != null)
            {
                result.Name = task.Name;
                result.Description = task.Description;
                result.Done = task.Done;

                _context.SaveChanges();
            }
        }
        public void Delete(int taskId)
        {
            var result = _context.Table.SingleOrDefault(x => x.TaskId == taskId);
            if(result != null)
            {
                _context.Table.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
