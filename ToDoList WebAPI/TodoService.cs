namespace ToDoList_WebAPI
{
    public class TodoService
    {
        int nextID = 0;
        private readonly List<TodoList> _todoList = new();

        public TodoList AddTodo(JsonMessage title)
        {
            var todo = new TodoList(title.message, nextID);
            nextID++;
            _todoList.Add(todo);
            return todo;
        }

        public List<TodoList> Retrieve()
        {
            return _todoList;
        }

        public int Tick(int Id)
        {
            for (int i = 0; i < _todoList.Count; i++)
            {
                if (_todoList[i].ID == Id)
                {
                    _todoList[i].Done();
                    Console.WriteLine($"{_todoList[i].Title} is done!");
                    return 0;
                }
            }

            Console.WriteLine("Task does not exist");
            return 0;
        }

        public void Clear()
        {
            _todoList.Clear();
        }

    }
}
