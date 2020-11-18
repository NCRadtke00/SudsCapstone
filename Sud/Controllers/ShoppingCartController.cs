using Microsoft.AspNetCore.Mvc;
using Sud.Data;
using Sud.Models;
using Sud.Models.ViewModels;
using Sud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IClotheRepository cr;
        private readonly ApplicationDbContext db;
        private readonly ShoppingCart sc;

        public ShoppingCartController(IClotheRepository clothesRepository,
            ShoppingCart shoppingCart, ApplicationDbContext context)
        {
            cr = (IClotheRepository)clothesRepository;
            sc = shoppingCart;
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            var items = await sc.GetShoppingCartItemsAsync();
            sc.ShoppingCartItems = items;
            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = sc,
                ShoppingCartTotal = sc.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
        public async Task<IActionResult> AddToShoppingCart(int clothesId)
        {
            var selectedClothes = await cr.GetByIdAsync(clothesId);
            if (selectedClothes != null)
            {
                await sc.AddToCartAsync(selectedClothes, 1);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveFromShoppingCart(int clothesId)
        {
            var selectedClothes = await cr.GetByIdAsync(clothesId);
            if (selectedClothes != null)
            {
                await sc.RemoveFromCartAsync(selectedClothes);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ClearCart()
        {
            await sc.ClearCartAsync();
            return RedirectToAction("Index");
        }
    }
}
