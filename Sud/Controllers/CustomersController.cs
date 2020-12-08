using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Sud.Data;
using Sud.Models;

namespace Sud.Controllers
{

    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private static readonly HttpClient httpClient;
        static CustomersController()
        {
            httpClient = new HttpClient();
        }
        public CustomersController(ApplicationDbContext context)
        {
            _db = context;
        }

        // GET: Customers
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.Customer.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (customer == null)
            {
                return RedirectToAction("Create");
            }
            return View("Details", customer);
        }
        public IActionResult Details(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _db.Customer.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        public IActionResult Create() //get
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer) // post
        {
            //the line of code below this isnt working with redirect to api keys
            //string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={customer.Address.StreetAddress},+{customer.Address.City},+{customer.Address.State},{customer.Address.ZipCode}&key={Sud.APIKeys.Key}";
            
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={customer.Address.StreetAddress},+{customer.Address.City},+{customer.Address.State},{customer.Address.ZipCode}&key=AIzaSyDXS87aNNUzLOl40Q1kuMBWqup20n-508M";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                JObject geoCode = JObject.Parse(jsonResult);
                customer.Address.Latitude = (double)geoCode["results"][0]["geometry"]["location"]["lat"];

                customer.Address.Longitude = (double)geoCode["results"][0]["geometry"]["location"]["lng"];
            }
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _db.Add(customer);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Customer customer)
        //{
        //    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    customer.IdentityUserId = userId;
        //    customer.Address = await GeocodeAddress(customer.Address);
        //    _db.Add(customer);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private async Task<Address> GeocodeAddress(Address address)
        //{
        //    string formattedAddress = address.ToString();
        //    Uri fullURL = new Uri("https://maps.googleapis.com/maps/api/geocode/json?address=" + formattedAddress + "&key=" + APIKeys.GoogleMapsKey);
        //    var response = await httpClient.GetAsync(fullURL);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var task = response.Content.ReadAsStringAsync().Result;
        //        JObject mapsData = JsonConvert.DeserializeObject<JObject>(task);
        //        address.Latitude = Convert.ToDouble(mapsData["results"][0]["geometry"]["location"]["lat"]);
        //        address.Longitude = Convert.ToDouble(mapsData["results"][0]["geometry"]["location"]["lng"]);
        //    }

        //    return address;
        //}

        //private string ParseAddress(Address address)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    for (int i = 0; i < address.StreetAddress; i++)
        //    {
        //        if (address.StreetAddress[i] == ' ')
        //        {
        //            stringBuilder.Append("+");
        //        }
        //        else
        //        {
        //            stringBuilder.Append(address.StreetAddress[i]);
        //        }
        //    }
        //    stringBuilder.Append(",+");
        //    for (int i = 0; i < address.City.Length; i++)
        //    {
        //        if (address.City[i] == ' ')
        //        {
        //            stringBuilder.Append("+");
        //        }
        //        else
        //        {
        //            stringBuilder.Append(address.City[i]);
        //        }
        //    }
        //    stringBuilder.Append(",+");
        //    for (int i = 0; i < address.State.Length; i++)
        //    {
        //        if (address.State[i] == ' ')
        //        {
        //            stringBuilder.Append("+");
        //        }
        //        else
        //        {
        //            stringBuilder.Append(address.State[i]);
        //        }
        //    }
        //    return stringBuilder.ToString();
        //}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _db.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_db.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(customer);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_db.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        private bool CustomerExists(int id)
        {
            return _db.Customer.Any(e => e.Id == id);
        }
    }
}
