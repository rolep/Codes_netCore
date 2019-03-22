using codes_netCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace codes_netCore.Controllers
{
    public class NetworksController : Controller
    {
        private readonly ModelContext _context;

        public NetworksController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult NetworkDropDown(int? countryId)
        {
            if (countryId == null) return new StatusCodeResult(StatusCodes.Status400BadRequest);

            var networks = _context.Countries.Find(countryId).Networks;
            ViewBag.NetworkId = new SelectList(networks, "Id", "Name");
            return PartialView();
        }

        public IActionResult Index(int? id)
        {
            if (id == null) return new StatusCodeResult(StatusCodes.Status400BadRequest);
            var modelContext = _context.Countries.Find(id).Networks;
            return PartialView(modelContext.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.ColorId = new SelectList(_context.Colors, "Id", "Hex");
            ViewBag.CountryId = new SelectList(_context.Countries, "Id", "Name");
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,CountryId,ColorId,Name")] Network network)
        {
            if (ModelState.IsValid)
            {
                if (_context.Networks.Where(c => c.Name == network.Name).FirstOrDefault() == null)
                {
                    _context.Add(network);
                    await _context.SaveChangesAsync();
                    return new StatusCodeResult(StatusCodes.Status200OK);
                }
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            return new StatusCodeResult(StatusCodes.Status400BadRequest);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var network = await _context.Networks.FindAsync(id);
            if (network == null)
            {
                return NotFound();
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id", network.ColorId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", network.CountryId);
            return View(network);
        }

        private bool NetworkExists(int id)
        {
            return _context.Networks.Any(e => e.Id == id);
        }
    }
}
