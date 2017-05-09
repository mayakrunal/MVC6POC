using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index() => View("Result", $"This is a derived controller");

        public ViewResult Headers() => View("DictionaryResult", Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First()));

    }
}
