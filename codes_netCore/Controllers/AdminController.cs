using codes_netCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace codes_netCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly ModelContext _context;

        public AdminController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Admin()
        {
            List<Country> countries = new List<Country>();
            foreach (var country in _context.Countries)
            {
                countries.Add(new Country() { Id = country.Id, Name = $"{country.Code} {country.Name}" });
            }
            ViewBag.CountryId = new SelectList(countries, "Id", "Name");
            ViewBag.ColorId = new SelectList(_context.Colors, "Id", "Hex");

            return View();
        }
    }
}