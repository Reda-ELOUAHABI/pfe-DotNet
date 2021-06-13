using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pfe.Data;
using pfe.Models;

namespace pfe.Controllers
{
    public class FilieresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilieresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Filieres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Filiere.ToListAsync());
        }

        // GET: Filieres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere
                   .Include(s => s.Students)

                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.FiliereId == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // GET: Filieres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filieres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiliereId,NomFiliere")] Filiere filiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filiere);
        }

        // GET: Filieres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere.FindAsync(id);
            if (filiere == null)
            {
                return NotFound();
            }
            return View(filiere);
        }

        // POST: Filieres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FiliereId,NomFiliere")] Filiere filiere)
        {
            if (id != filiere.FiliereId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiliereExists(filiere.FiliereId))
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
            return View(filiere);
        }

        // GET: Filieres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filiere = await _context.Filiere
                .FirstOrDefaultAsync(m => m.FiliereId == id);
            if (filiere == null)
            {
                return NotFound();
            }

            return View(filiere);
        }

        // POST: Filieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filiere = await _context.Filiere.FindAsync(id);
            _context.Filiere.Remove(filiere);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiliereExists(int id)
        {
            return _context.Filiere.Any(e => e.FiliereId == id);
        }
    }
}
