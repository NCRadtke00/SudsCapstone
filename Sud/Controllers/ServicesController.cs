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
        public ServicesController(ApplicationDbContext context, ServicesRepository serviceRepo)
        {
            db = context;
            cr = (IServicesRepository)serviceRepo;
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
            var services = await cr.GetByIdAsync(id);
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Services services)
        {
            if (ModelState.IsValid)
            {
                cr.Add(services);
                await cr.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(services);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var services = await cr.GetByIdAsync(id);
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Services services)
        {
            if (id != services.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    cr.Update(services);
                    await cr.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicesExists(services.Id))
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
            return View(services);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var services = await cr.GetByIdAsync(id);
            if (services == null)
            {
                return NotFound();
            }
            return View(services);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var services = await cr.GetByIdAsync(id);
            cr.Remove(services);
            await cr.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private bool ServicesExists(int id)
        {
            return cr.Exists(id);
        }
    }
}
