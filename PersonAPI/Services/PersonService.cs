using Microsoft.EntityFrameworkCore;
using PersonAPI.DatabaseContext;
using PersonAPI.Models;

namespace PersonAPI.Services
{
    public class PersonService : IPersonService
    {
        private readonly DBContext _dbContext;

        public PersonService(DBContext personContext)
        {
            _dbContext = personContext ?? throw new ArgumentNullException(nameof(personContext));
        }

        public async Task<List<Person>> GetPersons()
        {
            return await _dbContext.Person
                         .Select(x => x)
                         .ToListAsync();
        }

        public async Task<Person> GetPerson(int id)
        {
            Person person = await (from p in _dbContext.Person
                          where p.Id == id
                                   //join t in _dbContext.PersonType
                                   //on p.Type equals t.Id

                                   select new Person
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Age = p.Age,
                              Type = p.Type
                          }).FirstOrDefaultAsync();

            return person;
        }

        public async Task<Person> UpdatePerson(Person personData)
        {
            bool isNew = personData.Id == 0;

            if (isNew)
            {
                _dbContext.Person.Add(personData);
            }
            else
            {
                _dbContext.Person.Attach(personData);
                _dbContext.Entry(personData).State = EntityState.Modified;
            }

            await _dbContext.SaveChangesAsync();

            return personData;
        }


        public async Task<Person> DeletePerson(int personId)
        {
            var person = await _dbContext.Person.FindAsync(personId);
            if (person == null)
            {
                return person;
            }

            _dbContext.Person.Remove(person);
            await _dbContext.SaveChangesAsync();

            return person;
        }

        public async Task<List<PersonType>> GetPersonTypes()
        {
            return await _dbContext.PersonType
                         .Select(x => x)
                         .ToListAsync();
        }
    }
}
