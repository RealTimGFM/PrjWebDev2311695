using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PrjWebDev2311695.Data;
using PrjWebDev2311695.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrjWebDev2311695.Controllers
{
    public class CitiesController : Controller
    {
        private readonly PrjWebDev2311695Context _context;

        public CitiesController(PrjWebDev2311695Context context)
        {
            _context = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index()
        {
            return View(await _context.City.ToListAsync());
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName,Province")] City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,CityName,Province")] City city)
        {
            if (id != city.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.CityId))
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
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.City
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _context.City.FindAsync(id);
            if (city != null)
            {
                _context.City.Remove(city);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(int id)
        {
            return _context.City.Any(e => e.CityId == id);
        }
        [HttpGet]
        public IActionResult Search()
        {
            // render the blank form
            return View(new City());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search([Bind("CityId,CityName,Province")] City city)
        {
            List<City> found = new List<City>();
            //check both
            if (!string.IsNullOrWhiteSpace(city.CityName) && !string.IsNullOrWhiteSpace(city.Province))
            {
                found = await _context.City
                    .Where(c => c.CityName.Contains(city.CityName) && c.Province.Contains(city.Province))
                    .ToListAsync();
            }
            //check name 
            else if (!string.IsNullOrWhiteSpace(city.CityName))
            {
                found = await _context.City
                    .Where(c => c.CityName.Contains(city.CityName))
                    .ToListAsync();
            }
            //check provincee
            else if (!string.IsNullOrWhiteSpace(city.Province))
            {
                found = await _context.City
                    .Where(c => c.Province.Contains(city.Province))
                    .ToListAsync();
            }
            //simply return nothing 
            else
            {
                Console.WriteLine("NOT AN ERROR, ITS JUST EMPTY");
                found = new List<City>();
            }

            TempData["CityResults"] = JsonConvert.SerializeObject(found);
            return RedirectToAction(nameof(SearchResults));
        }
        public IActionResult SearchResults()
        {
            string resultsJ = TempData["CityResults"] as string ?? "[]";
            var results = JsonConvert.DeserializeObject<List<City>>(resultsJ);

            if (results.Count > 0)
            {
                ViewBag.SearchResultsMessage = $"Found {results.Count} item(s) matching your search.";
            }
            else
            {
                ViewBag.SearchResultsMessage = "No results found.";
            }

            return View(results);
        }
    }
}
