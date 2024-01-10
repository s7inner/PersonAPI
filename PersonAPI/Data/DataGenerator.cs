using Microsoft.EntityFrameworkCore;
using PersonAPI.Models;

namespace PersonAPI.Data
{
    public class DataGenerator
    {
        public static async Task InitializePersonsAsync(IServiceProvider serviceProvider)
        {
            using (var context = new PersonDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<PersonDbContext>>()))
            {
                if (context.Persons.Any())
                {
                    return; // База даних вже була заповнена
                }

                var personsToAdd = new[]
                {
                    new Person { FirstName = "John", LastName = "Doe" },
                    new Person { FirstName = "Jane", LastName = "Smith" },
                    new Person { FirstName = "Michael", LastName = "Johnson" }
                };

                await context.Persons.AddRangeAsync(personsToAdd);
                await context.SaveChangesAsync();
            }
        }
    }
}
