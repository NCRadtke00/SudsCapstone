using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sud.Data;
using Sud.Models;

namespace Sud.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> _userManager;
        public ReviewsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            db = context;
            _userManager = userManager;
        }
       
        public async Task<IActionResult> EmployeeIndex()
        {
            var reviews = await db.Reviews.Include(r => r.Clothes).Include(r => r.User).ToListAsync();
            return View(reviews);
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            bool isEmployee = await _userManager.IsInRoleAsync(user, "Admin");

            if (isEmployee)
            {
                var allReviews = db.Reviews.Include(r => r.Clothes).Include(r => r.User).ToList();
                return View(allReviews);
            }
            else
            {
                var reviews = db.Reviews.Include(r => r.Clothes).Include(r => r.User)
                    .Where(r => r.User == user).ToList();
                return View(reviews);
            }
        }
        [AllowAnonymous]
        public async Task<IActionResult> ListAll()
        {
            var reviews = await db.Reviews.Include(r => r.Clothes).Include(r => r.User).ToListAsync();
            return View(reviews);
        }
        private async Task<List<Reviews>> SortReviews(string sortBy, bool isDescending)
        {
            var reviewsList = db.Reviews.Include(r => r.Clothes).Include(r => r.User);
            IQueryable<Reviews> result;

            if (sortBy == null || sortBy == "")
            {
                result = reviewsList;
            }

            if (isDescending == false)
            {
                switch (sortBy.ToLower())
                {
                    case "date":
                        result = reviewsList.OrderBy(x => x.Date);
                        break;
                    case "grade":
                        result = reviewsList.OrderBy(x => x.Grade);
                        break;
                    case "title":
                        result = reviewsList.OrderBy(x => x.Title);
                        break;
                    case "clothing name":
                        result = reviewsList.OrderBy(x => x.Clothes.Name);
                        break;
                    default:
                        result = reviewsList.OrderBy(x => x.Clothes.Id);
                        break;
                }
            }
            else
            {
                switch (sortBy.ToLower())
                {
                    case "date":
                        result = reviewsList.OrderByDescending(x => x.Date);
                        break;
                    case "grade":
                        result = reviewsList.OrderByDescending(x => x.Grade);
                        break;
                    case "title":
                        result = reviewsList.OrderByDescending(x => x.Title);
                        break;
                    case "clothing name":
                        result = reviewsList.OrderByDescending(x => x.Clothes.Name);
                        break;
                    default:
                        result = reviewsList.OrderByDescending(x => x.Clothes.Id);
                        break;
                }
            }
            return await result.ToListAsync();
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AjaxListReviews(string sortBy, bool isDescending)
        {
            var listOfReviews = await SortReviews(sortBy, isDescending);

            return PartialView(listOfReviews);
        }
        [AllowAnonymous]
        public async Task<IActionResult> ClothingReviews(int? clothesId)
        {
            if (clothesId == null)
            {
                return NotFound();
            }
            var clothes = db.Clothes.FirstOrDefault(x => x.Id == clothesId);
            if (clothes == null)
            {
                return NotFound();
            }
            var reviews = await db.Reviews.Include(r => r.Clothes).Include(r => r.User).Where(x => x.Clothes.Id == clothes.Id).ToListAsync();
            if (reviews == null)
            {
                return NotFound();
            }
            ViewBag.ClothesName = clothes.Name;
            ViewBag.ClothesId = clothes.Id;
            return View(reviews);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reviews = await db.Reviews
                .Include(r => r.Clothes)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }
            return View(reviews);
        }
        public IActionResult CreateWithClothes(int? clothesId)
        {
            var review = new Reviews();
            if (clothesId == null)
            {
                return NotFound();
            }
            var clothes = db.Clothes.FirstOrDefault(p => p.Id == clothesId);
            if (clothes == null)
            {
                return NotFound();
            }
            review.Clothes = clothes;
            review.ClothesId = clothes.Id;
            ViewData["ClothesId"] = new SelectList(db.Clothes.Where(p => p.Id == clothesId), "Id", "Name");
            var listOfNumbers = new List<int>() { 1, 2, 3, 4, 5 };
            var listOfGrades = listOfNumbers.Select(x => new { Id = x, Value = x.ToString() });
            ViewData["Grade"] = new SelectList(listOfGrades, "Id", "Value");
            return View(review);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWithClothes(int clothesId, Reviews reviews)
        {
            if (clothesId != reviews.ClothesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                reviews.Id = Convert.ToInt32(userId);
                reviews.Date = DateTime.Now;
                db.Add(reviews);
                await db.SaveChangesAsync();
                return Redirect($"ClothesReviews?clothesId={clothesId}");
            }
            var listOfNumbers = new List<int>() { 1, 2, 3, 4, 5 };
            var listOfGrades = listOfNumbers.Select(x => new { Id = x, Value = x.ToString() });
            ViewData["Grade"] = new SelectList(listOfGrades, "Id", "Value", reviews.Grade);
            ViewData["ClothesId"] = new SelectList(db.Clothes.Where(p => p.Id == clothesId), "Id", "Name", reviews.ClothesId);
            return View(reviews);
        }
        public IActionResult Create()
        {
            var listOfNumbers = new List<int>() { 1, 2, 3, 4, 5 };
            var listOfGrades = listOfNumbers.Select(x => new { Id = x, Value = x.ToString() });
            ViewData["Grade"] = new SelectList(listOfGrades, "Id", "Value");
            ViewData["ClothesId"] = new SelectList(db.Clothes, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Grade,ClothesId")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                reviews.IdentityUserId = userId;
                reviews.Date = DateTime.Now;
                db.Add(reviews);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var listOfNumbers = new List<int>() { 1, 2, 3, 4, 5 };
            var listOfGrades = listOfNumbers.Select(x => new { Id = x, Value = x.ToString() });
            ViewData["Grade"] = new SelectList(listOfGrades, "Id", "Value", reviews.Grade);
            ViewData["ClothesId"] = new SelectList(db.Clothes, "Id", "Name", reviews.ClothesId);
            return View(reviews);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reviews = await db.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userRoles = await _userManager.GetRolesAsync(user);
            bool isAdmin = userRoles.Any(r => r == "Admin");
            if (reviews == null)
            {
                return NotFound();
            }
            if (isAdmin == false)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                if (reviews.IdentityUserId != userId)
                {
                    return BadRequest("You do not have permissions to edit this review.");
                }
            }
            var listOfNumbers = new List<int>() { 1, 2, 3, 4, 5 };
            var listOfGrades = listOfNumbers.Select(x => new { Id = x, Value = x.ToString() });
            ViewData["Grade"] = new SelectList(listOfGrades, "Id", "Value", reviews.Grade);
            ViewData["ClothesId"] = new SelectList(db.Clothes, "Id", "Name", reviews.ClothesId);
            return View(reviews);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Grade,Date,ClothesId")] Reviews reviews)
        {
            if (id != reviews.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                try
                {
                    if (reviews.Date == null)
                    {
                        reviews.Date = DateTime.Now;
                    }
                    reviews.IdentityUserId = userId;
                    db.Update(reviews);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.Id))
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
            var listOfNumbers = new List<int>() { 1, 2, 3, 4, 5 };
            var listOfGrades = listOfNumbers.Select(x => new { Id = x, Value = x.ToString() });
            ViewData["Grade"] = new SelectList(listOfGrades, "Id", "Value", reviews.Grade);
            ViewData["ClothesId"] = new SelectList(db.Clothes, "Id", "Name", reviews.ClothesId);
            return View(reviews);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reviews = await db.Reviews
                .Include(r => r.Clothes)
                .SingleOrDefaultAsync(m => m.Id == id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userRoles = await _userManager.GetRolesAsync(user);
            bool isAdmin = userRoles.Any(r => r == "Admin");
            if (reviews == null)
            {
                return NotFound();
            }
            if (isAdmin == false)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                if (reviews.IdentityUserId != userId)
                {
                    return BadRequest("You do not have permissions to edit this review.");
                }
            }
            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviews = await db.Reviews.SingleOrDefaultAsync(m => m.Id == id);
            db.Reviews.Remove(reviews);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private bool ReviewsExists(int id)
        {
            return db.Reviews.Any(e => e.Id == id);
        }
    }
}
