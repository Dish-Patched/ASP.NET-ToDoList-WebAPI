using Microsoft.EntityFrameworkCore;

namespace ToDoList_WebAPI
{
    public class TodoService
    {
        int nextID = 0;
        private readonly TodoDBContext _context;

        public TodoService(TodoDBContext context)
        {
            _context = context;
        }

        async public Task<TodoList> AddTodo(JsonMessage title)
        {
            var todo = new TodoList(title.message, nextID);
            nextID++;
            _context.TodoDb.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        async public Task<List<TodoList>> Retrieve()
        {
            return await _context.TodoDb.ToListAsync();
        }

        async public Task<int> Tick(int Id)
        {
            var task = await _context.TodoDb.FindAsync(Id);

            if (task != null)
            {
                task.Done();
                await _context.SaveChangesAsync();
                return 0;
            }

            Console.WriteLine("Task does not exist");
            return 0;
        }

        async public Task Clear()
        {
            _context.TodoDb.RemoveRange(_context.TodoDb);
            await _context.SaveChangesAsync();
        }

    }
}
