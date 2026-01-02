using Microsoft.EntityFrameworkCore;
using ToDoList_WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<TodoService>();

builder.Services.AddDbContext<TodoDBContext>(options => options.UseSqlite("Data Source = todos.db"));

var app = builder.Build();

app.MapControllers();

app.Run();
