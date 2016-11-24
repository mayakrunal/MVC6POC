using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMovie.ViewComponents
{
    public class WatchedMovieViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public WatchedMovieViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(bool isWatched)
        {
            var items = await _db.Movie.Where(x => x.IsWatched == isWatched).ToListAsync();
            return View(items);
        }
    }
}
