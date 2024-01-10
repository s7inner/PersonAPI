using PersonAPI.Interfaces;
using PersonAPI.Models;

namespace PersonAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            return await _personRepository.GetPersonsAsync();
        }

        public async Task<Person> GetPersonByIdAsync(Guid id)
        {
            return await _personRepository.GetPersonByIdAsync(id);
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            return await _personRepository.CreatePersonAsync(person);
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            return await _personRepository.UpdatePersonAsync(person);
        }

        public async Task<bool> DeletePersonAsync(Guid id)
        {
            return await _personRepository.DeletePersonAsync(id);
        }
    }
}
