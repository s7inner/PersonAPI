using PersonAPI.Models;
using System.Threading.Tasks;

namespace PersonAPI.Interfaces
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPersonsAsync();
        Task<Person> GetPersonByIdAsync(Guid id);
        Task<Person> CreatePersonAsync(Person person);
        Task<bool> UpdatePersonAsync(Person person);
        Task<bool> DeletePersonAsync(Guid id);
    }
}
