using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Components
{
    public class ServiceMenu : ViewComponent
    {
        private readonly ApplicationDbContext db;
        public ServiceMenu(ApplicationDbContext context)
        {
            db = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await db.Services.OrderBy(c => c.Name).ToListAsync();
            return View(services);
        }
    }
}
