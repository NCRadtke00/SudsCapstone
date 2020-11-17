using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Components
{
    public class CarouselMenu : ViewComponent
    {
        private readonly ApplicationDbContext db;
        public CarouselMenu(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clothes = await db.Clothes.Where(x => x.IsPopularItem).ToListAsync();
            return View(clothes);
        }
    }
}
