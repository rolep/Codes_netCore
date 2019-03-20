using codes_netCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace codes_netCore.Controllers
{
    public class ColorsController : Controller
    {
        private readonly ModelContext _context;

        public ColorsController(ModelContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Colors.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Hex")] Color color)
        {
            if (ModelState.IsValid)
            {
                _context.Add(color);
                await _context.SaveChangesAsync();
                return new StatusCodeResult(StatusCodes.Status200OK);
            }
            return new StatusCodeResult(StatusCodes.Status400BadRequest);
        }
    }
}
