using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvidenceVozidel.Data;
using EvidenceVozidel.Models;

namespace EvidenceVozidel.Controllers
{
    public class AutomobilController : Controller
    {
        private readonly EvidenceVozidelContext _context;

        public AutomobilController(EvidenceVozidelContext context)
        {
            _context = context;
        }

        // GET: Automobil
        public async Task<IActionResult> Index()
        {
            return View(await _context.Automobil.ToListAsync());
        }

        // GET: Automobil/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // GET: Automobil/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Automobil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Znacka,Model")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automobil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(automobil);
        }

        // GET: Automobil/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil.FindAsync(id);
            if (automobil == null)
            {
                return NotFound();
            }
            return View(automobil);
        }

        // POST: Automobil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("Id,Znacka,Model")] Automobil automobil)
        {
            if (id != automobil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobilExists(automobil.Id))
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
            return View(automobil);
        }

        // GET: Automobil/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // POST: Automobil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var automobil = await _context.Automobil.FindAsync(id);
            if (automobil != null)
            {
                _context.Automobil.Remove(automobil);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomobilExists(uint id)
        {
            return _context.Automobil.Any(e => e.Id == id);
        }
    }
}
