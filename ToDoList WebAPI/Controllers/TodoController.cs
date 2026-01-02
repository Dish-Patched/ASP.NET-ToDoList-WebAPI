using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace ToDoList_WebAPI.Controllers
{
    [Route("ToDo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todo;

        public TodoController(TodoService todo)
        {
            _todo = todo;
        }

        [HttpPost]
        public TodoList Post(JsonMessage msg)
        {
            TodoList Todo = _todo.AddTodo(msg);
            return Todo;
        }

        [HttpGet]
        public List<TodoList> Get()
        {
            return _todo.Retrieve();
        }

        [HttpPut("{Id}")]
        public void Put(int Id)
        {
            _todo.Tick(Id);
        }

        [HttpDelete("Clear")]
        public void Delete()
        {
            _todo.Clear();
            Console.WriteLine("Cleared List");
        }
    }
}
