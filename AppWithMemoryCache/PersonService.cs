using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppWithMemoryCache
{
    public class PersonService
    {
        private readonly IMemoryCache _cache;
        private readonly DataContext _data;

        public PersonService(DataContext data, IMemoryCache cache)
        {
            this._data = data;
            this._cache = cache;
        }

        public async Task<IEnumerable<Person>> GetAsync()
        {
            var persons = await this._data.Persons.ToListAsync();
            return persons;
        }

        public async Task<Person> GetAsync(Guid id)
        {
            if (!this._cache.TryGetValue(id, out Person person))
            {
                person = await _data.Persons.FirstOrDefaultAsync(x => x.Id == id);
                if (person is not null)
                {
                    this._cache.Set(person.Id, person, TimeSpan.FromMinutes(5));
                }
            }
            return person;
        }

        public async Task<Person> Add(Person person)
        {
            this._data.Add(person);
            int n = await this._data.SaveChangesAsync();

            if (n > 0)
            {
                this._cache.Set(person.Id, person, TimeSpan.FromMinutes(5));
            }

            return person;
        }

        public async Task<bool> ExistAsync(Guid? id)
        {
            if (id.HasValue)
                return await this._data.Persons.AnyAsync(x => x.Id == id);
            else return false;
        }
    }
}
