using PersonAPI.Models;

namespace PersonAPI.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> GetPersonsAsync();
        Task<Person> GetPersonByIdAsync(Guid id);
        Task<Person> CreatePersonAsync(Person person);
        Task<bool> UpdatePersonAsync(Person person);
        Task<bool> DeletePersonAsync(Guid id);
    }
}
