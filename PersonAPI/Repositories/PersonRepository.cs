using Microsoft.EntityFrameworkCore;
using PersonAPI.Data;
using PersonAPI.Interfaces;
using PersonAPI.Models;

namespace PersonAPI.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _context;

        public PersonRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(Guid id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeletePersonAsync(Guid id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return false;
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
