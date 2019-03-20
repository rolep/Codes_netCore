using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using codes_netCore.Models;
using Microsoft.AspNetCore.Http;

namespace codes_netCore.Controllers
{
    public class NetworksController : Controller
    {
        private readonly ModelContext _context;

        public NetworksController(ModelContext context)
        {
            _context = context;
        }

        // GET: Networks
        public IActionResult Index(int? id)
        {
            if (id == null) return new StatusCodeResult(StatusCodes.Status400BadRequest);
            var modelContext = _context.Countries.Find(id).Networks;
            return PartialView(modelContext.ToList());
        }
        
        public IActionResult Create()
        {
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id");
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,CountryId,ColorId,Name")] Network network)
        {
            if (ModelState.IsValid)
            {
                _context.Add(network);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id", network.ColorId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", network.CountryId);
            return View(network);
        }

        // GET: Networks/Edit/5
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

        // POST: Networks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountryId,ColorId,Name")] Network network)
        {
            if (id != network.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(network);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NetworkExists(network.Id))
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
            ViewData["ColorId"] = new SelectList(_context.Colors, "Id", "Id", network.ColorId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", network.CountryId);
            return View(network);
        }

        // GET: Networks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var network = await _context.Networks
                .Include(n => n.Color)
                .Include(n => n.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (network == null)
            {
                return NotFound();
            }

            return View(network);
        }

        // POST: Networks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var network = await _context.Networks.FindAsync(id);
            _context.Networks.Remove(network);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NetworkExists(int id)
        {
            return _context.Networks.Any(e => e.Id == id);
        }
    }
}
