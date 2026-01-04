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
        async public Task<TodoList> Post(JsonMessage msg)
        {
            TodoList Todo = await _todo.AddTodo(msg);
            return Todo;
        }

        [HttpGet]
        async public Task<List<TodoList>> Get()
        {
            return await _todo.Retrieve();
        }

        [HttpPut("{Id}")]
        async public Task Put(int Id)
        {
            await _todo.Tick(Id);
        }

        [HttpDelete("Clear")]
        async public Task Delete()
        {
            await _todo.Clear();
            Console.WriteLine("Cleared List");
        }
    }
}
