using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;

namespace MVCMovie.Controllers
{
    public class HomeController : Controller
    {

        private readonly IFileProvider _fileprovider;

        public HomeController(IFileProvider fileprovider)
        {
            _fileprovider = fileprovider;
        }
        public IActionResult Index()
        {
            HttpContext?.Session?.SetString("test", "asdfadsfa");
            ViewData["test"] = HttpContext?.Session?.GetString("test");

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Files()
        {
            var contents = _fileprovider.GetDirectoryContents("");

            return View(contents);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
