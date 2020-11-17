using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sud.Data;
using Sud.Models;
using Microsoft.AspNetCore.Authorization;
using Sud.Repositories;

namespace Sud.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClothesController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IClotheRepository cr;


        public ClothesController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: Clothes
        public async Task<IActionResult> Index()
        {
            return View(await cr.GetAllIncludedAsync());
        }

        // GET: Clothes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await db.Clothes
                .Include(c => c.Services)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // GET: Clothes/Create
        public IActionResult Create()
        {
            ViewData["ServicesId"] = new SelectList(db.Services, "Id", "Name");
            return View();
        }

        // POST: Clothes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,ImageUrl,IsPopularItem,ServicesId")] Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                db.Add(clothes);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServicesId"] = new SelectList(db.Services, "Id", "Name", clothes.ServicesId);
            return View(clothes);
        }

        // GET: Clothes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await db.Clothes.FindAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }
            ViewData["ServicesId"] = new SelectList(db.Services, "Id", "Name", clothes.ServicesId);
            return View(clothes);
        }

        // POST: Clothes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,ImageUrl,IsPopularItem,ServicesId")] Clothes clothes)
        {
            if (id != clothes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(clothes);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothesExists(clothes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServicesId"] = new SelectList(db.Services, "Id", "Name", clothes.ServicesId);
            return View(clothes);
        }

        // GET: Clothes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await db.Clothes
                .Include(c => c.Services)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clothes == null)
            {
                return NotFound();
            }

            return View(clothes);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothes = await db.Clothes.FindAsync(id);
            db.Clothes.Remove(clothes);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothesExists(int id)
        {
            return db.Clothes.Any(e => e.Id == id);
        }
    }
}
