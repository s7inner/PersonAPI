using Microsoft.AspNetCore.Mvc;
using PersonAPI.Interfaces;
using PersonAPI.Models;

namespace PersonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            var persons = await _personService.GetPersonsAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(Guid id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> CreatePerson([FromBody] Person person)
        {
            var createdPerson = await _personService.CreatePersonAsync(person);
            return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.Id }, createdPerson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(Guid id, [FromBody] Person personToUpdate)
        {
            var existingPerson = await _personService.GetPersonByIdAsync(id);
            if (existingPerson == null)
            {
                return NotFound("Person not found.");
            }

            // Update the properties of the existingPerson entity with the values from personToUpdate
            existingPerson.FirstName = personToUpdate.FirstName;
            existingPerson.LastName = personToUpdate.LastName;

            var updated = await _personService.UpdatePersonAsync(existingPerson);
            if (updated)
            {
                return Ok("Person updated successfully.");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update the person.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(Guid id)
        {
            var existingPerson = await _personService.GetPersonByIdAsync(id);
            if (existingPerson == null)
            {
                return NotFound("Person not found.");
            }

            var deleted = await _personService.DeletePersonAsync(id);
            if (!deleted)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete the person.");
            }

            return Ok("Person successfully deleted.");
        }

    }
}
