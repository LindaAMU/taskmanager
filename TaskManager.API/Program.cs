using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Context;

var builder = WebApplication.CreateBuilder(args);

/* BD InMemory */
builder.Services.AddDbContext<TaskManagerContext>(opt => opt.UseInMemoryDatabase("ManagerDb"));

/* Agregar Controladores */
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();

app.UseCors("PolicyCors");

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
