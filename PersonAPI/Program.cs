using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;
using PersonAPI.Interfaces;
using PersonAPI.Repositories;
using PersonAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// ConnectionString
builder.Services.AddDbContext<PersonDbContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("AppConnectionString"))
    );

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//Ініціалізація даними через DataGenerator, якщо база пуста
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<PersonDbContext>();
        await DataGenerator.InitializePersonsAsync(serviceProvider);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

app.Run();
