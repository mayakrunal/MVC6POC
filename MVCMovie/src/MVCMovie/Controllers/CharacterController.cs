using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCMovie.Services;
using MVCMovie.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCMovie.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterRepository _characterRepository;
        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            PopulateCharactersIfNoneExist();
            var characters = _characterRepository.ListAll();
            return View(characters);
        }

        private void PopulateCharactersIfNoneExist()
        {
            if (!_characterRepository.ListAll().Any())
            {
                _characterRepository.Add(new Character("Darth Maul"));
                _characterRepository.Add(new Character("Darth Vader"));
                _characterRepository.Add(new Character("Yoda"));
                _characterRepository.Add(new Character("Mace Windu"));
            }
        }
    }
}
