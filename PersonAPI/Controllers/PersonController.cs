using Microsoft.AspNetCore.Mvc;
using PersonAPI.Models;
using PersonAPI.Services;

namespace PersonAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        #region Fields

        private readonly IPersonService _personService;

        #endregion

        #region Construnctors

        public PersonController(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }

        #endregion

        #region Endpoints

        [HttpGet("list")]
        public async Task<ActionResult> GetPersons()
        {
            List<Person> personList = await _personService.GetPersons();
            return Ok(personList);
        }

        [HttpGet("person")]
        public async Task<ActionResult> GetPerson([FromQuery]int personId)
        {
            Person person = await _personService.GetPerson(personId);
            return Ok(person);
        }

        [HttpGet("types")]
        public async Task<ActionResult> GetPersonTypes()
        {
            List<PersonType> personTypeList = await _personService.GetPersonTypes();
            return Ok(personTypeList);
        }

        [HttpPost]
        public async Task<ActionResult> UpdatePerson([FromBody] Person personData)
        {
            Person returnValue = await _personService.UpdatePerson(personData);

            return Ok(returnValue);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeletePerson([FromQuery] int personId)
        {
            Person returnValue = await _personService.DeletePerson(personId);
            return (returnValue == null ? NotFound() : NoContent());
        }

        #endregion
    }
}
