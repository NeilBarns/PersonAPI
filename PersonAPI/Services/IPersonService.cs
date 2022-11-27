using PersonAPI.Models;

namespace PersonAPI.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPersons();
        Task<Person> GetPerson(int personId);
        Task<Person> UpdatePerson(Person personData);
        Task<Person> DeletePerson(int personId);
        Task<List<PersonType>> GetPersonTypes();
    }
}
