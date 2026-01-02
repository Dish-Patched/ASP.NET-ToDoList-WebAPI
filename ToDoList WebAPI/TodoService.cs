namespace ToDoList_WebAPI
{
    public class TodoService
    {
        private readonly List<TodoList> _todoList = new();

        public TodoList AddTodo(JsonMessage title)
        {
            var todo = new TodoList(title.message);
            _todoList.Add(todo);
            return todo;
        }

        public List<TodoList> Retrieve()
        {
            return _todoList;
        }

    }
}
