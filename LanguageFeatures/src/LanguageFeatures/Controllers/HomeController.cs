using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<string> results = new List<string>();
            foreach (var p in Product.GetProducts())
            {
                string Name = p?.Name ?? "<No Name>";
                decimal? Price = p?.Price ?? 0;
                string Relatedname = p?.Related?.Name ?? "<No Name>";
                results.Add($"{nameof(Name)} : {Name}, {nameof(Price)}: {Price}, {nameof(Relatedname)}: {Relatedname }");
            }

            //Dictionary<string, Product> products = new Dictionary<string, Product>
            //{
            //    ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
            //    ["Life jacket"] = new Product { Name = "Life jacket", Price = 48.95M }
            //};

            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

            //return View(new string[] {$"Total : {cart.TotalPrices():C2}" });
            return View(results);
        }

        public async Task<IActionResult> Index2()
        {
            long? length = await MyAsyncMethods.GetPageLength();
            return View(new string[] { $"Length: {length}" });
        }
    }
}
