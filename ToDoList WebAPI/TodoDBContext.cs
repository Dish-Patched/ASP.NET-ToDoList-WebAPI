using Microsoft.EntityFrameworkCore;

namespace ToDoList_WebAPI
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options)
        {
        }

        public DbSet<TodoList> TodoDb { get; set; }
    }
}
