using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sud.Data;
using Sud.Models;
using Sud.Repositories;

namespace Sud.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IServicesRepository cr;
        public ServicesController(ApplicationDbContext context, ServicesRepository categoryRepo)
        {
            db = context;
            cr = (IServicesRepository)categoryRepo;
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
            var categories = await cr.GetByIdAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Services categories)
        {
            if (ModelState.IsValid)
            {
                cr.Add(categories);
                await cr.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categories);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categories = await cr.GetByIdAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Services categories)
        {
            if (id != categories.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    cr.Update(categories);
                    await cr.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(categories.Id))
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
            return View(categories);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categories = await cr.GetByIdAsync(id);
            if (categories == null)
            {
                return NotFound();
            }
            return View(categories);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categories = await cr.GetByIdAsync(id);
            cr.Remove(categories);
            await cr.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private bool CategoriesExists(int id)
        {
            return cr.Exists(id);
        }
    }
}
