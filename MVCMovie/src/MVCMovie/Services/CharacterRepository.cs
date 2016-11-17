using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCMovie.Models;
using MVCMovie.Data;

namespace MVCMovie.Services
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CharacterRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Character character)
        {
            _dbContext.Characters.Add(character);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Character> ListAll()
        {
            return _dbContext.Characters.AsEnumerable();
        }
    }
}
