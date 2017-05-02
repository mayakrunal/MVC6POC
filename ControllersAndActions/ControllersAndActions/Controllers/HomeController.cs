using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index() => View("SimpleForm");

        public IActionResult ReceiveForm(string name, string city)
        { 
            return View("Result", $"{name} lives in {city}");
        }
    }
}
