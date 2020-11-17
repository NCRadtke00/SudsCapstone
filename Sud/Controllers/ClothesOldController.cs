using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sud.Data;
using Sud.Models;
using Sud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Controllers
{
    public class ClothesOldController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IClotheRepository cr;
        public ClothesOldController(ApplicationDbContext context, ClotheRepository clothesRepo)
        {
            db = context;
            cr = (IClotheRepository)clothesRepo;
        }
        public async Task<IActionResult> Index()
        {
            return View(await cr.GetAllAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothes = await cr.GetByIdAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }
            return View(clothes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,ImageUrl,IsPopularItem")] Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                cr.Add(clothes);
                await cr.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clothes);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothes = await cr.GetByIdAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }
            return View(clothes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,ImageUrl,IsPopularItem")] Clothes clothes)
        {
            if (id != clothes.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    cr.Update(clothes);
                    await cr.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothingExists(clothes.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(clothes);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothes = await cr.GetByIdAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }
            return View(clothes);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clothes = await cr.GetByIdAsync(id);
            cr.Remove(clothes);
            await cr.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private bool ClothingExists(int id)
        {
            return cr.Exists(id);
        }
    }
}
