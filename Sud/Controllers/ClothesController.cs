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
using Sud.Models.ViewModels;

namespace Sud.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClothesController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IClotheRepository cr;
        private readonly IServicesRepository sr;
        public ClothesController(ApplicationDbContext context, ClotheRepository clotheRepository, ServicesRepository servicesRepository)
        {
            db = context;
            cr = (IClotheRepository)clotheRepository;
            sr = (IServicesRepository)servicesRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await cr.GetAllIncludedAsync());
        }
        [AllowAnonymous]
        public async Task<IActionResult> ListAll()
        {
            var model = new SearchClothesViewModel()
            {
                ClothesList = await cr.GetAllIncludedAsync(),
                SearchText = null
            };
            return View(model);
        }
        private async Task<List<Clothes>> GetClothesSearchList(string userInput)
        {
            userInput = userInput.ToLower().Trim();
            var result = db.Clothes.Include(p => p.Services)
                .Where(p => p
                    .Name.ToLower().Contains(userInput))
                    .Select(p => p).OrderBy(p => p.Name);
            return await result.ToListAsync();
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AjaxSearchList(string searchString)
        {
            var clothesList = await GetClothesSearchList(searchString);
            return PartialView(clothesList);
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ListAll([Bind("SearchText")] SearchClothesViewModel model)
        {
            var clothes = await cr.GetAllIncludedAsync();
            if (model.SearchText == null || model.SearchText == string.Empty)
            {
                model.ClothesList = clothes;
                return View(model);
            }
            var input = model.SearchText.Trim();
            if (input == string.Empty || input == null)
            {
                model.ClothesList = clothes;
                return View(model);
            }
            var searchString = input.ToLower();
            if (string.IsNullOrEmpty(searchString))
            {
                model.ClothesList = clothes;
            }
            else
            {
                var clothesList = await db.Clothes.Include(x => x.Services).Include(x => x.Reviews).OrderBy(x => x.Name)
                     .Where(p =>
                     p.Name.ToLower().Contains(searchString)
                  || p.Price.ToString("c").ToLower().Contains(searchString)
                  || p.Services.Name.ToLower().Contains(searchString))
                    .ToListAsync();
                if (clothesList.Any())
                {
                    model.ClothesList = clothesList;
                }
                else
                {
                    model.ClothesList = new List<Clothes>();
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ListServices(string serviceName)
        {
            bool serviceExtist = db.Services.Any(c => c.Name == serviceName);
            if (!serviceExtist)
            {
                return NotFound();
            }
            var service = await db.Services.FirstOrDefaultAsync(c => c.Name == serviceName);
            if (service == null)
            {
                return NotFound();
            }
            bool anyClothes = await db.Clothes.AnyAsync(x => x.Services == service);
            if (!anyClothes)
            {
                return NotFound($"No items were found in: {serviceName}");
            }
            var clothes = db.Clothes.Where(x => x.Services == service)
                .Include(x => x.Services).Include(x => x.Reviews);
            ViewBag.CurrentService = service.Name;
            return View(clothes);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothes = await cr.GetByIdIncludedAsync(id);
            if (clothes == null)
            {
                return NotFound();
            }
            return View(clothes);
        }
        [AllowAnonymous]
        public async Task<IActionResult> DisplayDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clothes = await cr.GetByIdIncludedAsync(id);
            double score;
            if (db.Reviews.Any(x => x.ClothesId == id))
            {
                var review = db.Reviews.Where(x => x.ClothesId == id);
                score = review.Average(x => x.Grade);
                score = Math.Round(score, 2);
            }
            else
            {
                score = 0;
            }
            ViewBag.AverageReviewScore = score;
            if (clothes == null)
            {
                return NotFound();
            }
            return View(clothes);
        }
        [AllowAnonymous]
        public async Task<IActionResult> SearchClothes()
        {
            var model = new SearchClothesViewModel()
            {
                ClothesList = await cr.GetAllIncludedAsync(),
                SearchText = null
            };
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchClothes([Bind("SearchText")] SearchClothesViewModel model)
        {
            var clothes = await cr.GetAllIncludedAsync();
            var search = model.SearchText.ToLower();
            if (string.IsNullOrEmpty(search))
            {
                model.ClothesList = clothes;
            }
            else
            {
                var clothesList = await db.Clothes.Include(x => x.Services).Include(x => x.Reviews).OrderBy(x => x.Name)
                    .Where(p =>
                     p.Name.ToLower().Contains(search)
                  || p.Price.ToString("c").ToLower().Contains(search)
                  || p.Services.Name.ToLower().Contains(search)).ToListAsync();
                if (clothesList.Any())
                {
                    model.ClothesList = clothesList;
                }
                else
                {
                    model.ClothesList = new List<Clothes>();
                }
            }
            return View(model);
        }
        public IActionResult Create()
        {
            ViewData["ServicesId"] = new SelectList(sr.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,ImageUrl,IsPopularItem,ServicesId")] Clothes clothes)
        {
            if (ModelState.IsValid)
            {
                cr.Add(clothes);
                await cr.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ServicesId"] = new SelectList(sr.GetAll(), "Id", "Name", clothes.ServicesId);
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
            ViewData["ServicesId"] = new SelectList(sr.GetAll(), "Id", "Name", clothes.ServicesId);
            return View(clothes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,ImageUrl,IsPopularItem,ServicesId")] Clothes clothes)
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
            ViewData["ServicesId"] = new SelectList(sr.GetAll(), "Id", "Name", clothes.ServicesId);
            return View(clothes);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clothes = await cr.GetByIdIncludedAsync(id);

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
