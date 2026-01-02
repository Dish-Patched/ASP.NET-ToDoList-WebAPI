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

        public TodoList AddTodo(JsonMessage title)
        {
            var todo = new TodoList(title.message, nextID);
            nextID++;
            _context.TodoDb.Add(todo);
            _context.SaveChanges();
            return todo;
        }

        public List<TodoList> Retrieve()
        {
            return _context.TodoDb.ToList();
        }

        public int Tick(int Id)
        {
            var task = _context.TodoDb.Find(Id);

            if (task != null)
            {
                task.Done();
                _context.SaveChanges();
                return 0;
            }

            Console.WriteLine("Task does not exist");
            return 0;
        }

        public void Clear()
        {
            _context.TodoDb.RemoveRange(_context.TodoDb);
            _context.SaveChanges();
        }

    }
}
