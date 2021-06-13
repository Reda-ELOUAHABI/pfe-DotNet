using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pfe.Data;
using pfe.Models;

namespace pfe.Controllers
{
    public class StagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stages

     [Authorize(Roles = "student")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stage.ToListAsync());
        }

        // GET: Stages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

             var stage = await _context.Stage
            .Include(s => s.Students)
            .Include(i => i.EncadrantInterne)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.StageId == id);


            if (stage == null)
            {
                return NotFound();
            }

            return View(stage);
        }

        // GET: Stages/Create
        public IActionResult Create()
        {
            ViewData["EnseignantId"] = new SelectList(_context.Enseignant, "EnseignantId", "Prenom");


            return View();
        }

        // POST: Stages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StageId,DateDebut,DateFin,EncadrantExterne,EnseignantId,OrganismeAceuil,PaysStage,Sujet,VilleStage")] Stage stage)
        {
          

            if (ModelState.IsValid)
            {



     /*           int id = 38;
                if (id == null)
                {
                    return NotFound();
                }
                var studentToUpdate = await _context.Student.FirstOrDefaultAsync(s => s.StudentId == id);

                studentToUpdate.StageId = stage.StageId;

                Console.WriteLine(studentToUpdate.Nom+ "  stage id : "+ studentToUpdate.StageId);


               try {
                    _context.Student.Update(studentToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(studentToUpdate.StudentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }  
     


      
      */




                _context.Add(stage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["EnseignantId"] = new SelectList(_context.Enseignant, "EnseigantId", "EnseigantId", stage.EnseignantId);
            return View(stage);
        }

        // GET: Stages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stage = await _context.Stage.FindAsync(id);
            if (stage == null)
            {
                return NotFound();
            }
            return View(stage);
        }

        // POST: Stages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StageId,DateDebut,DateFin,EncadrantExterne,OrganismeAceuil,PaysStage,Sujet,VilleStage")] Stage stage)
        {
            if (id != stage.StageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StageExists(stage.StageId))
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
            return View(stage);
        }

        // GET: Stages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stage = await _context.Stage
                .FirstOrDefaultAsync(m => m.StageId == id);
            if (stage == null)
            {
                return NotFound();
            }

            return View(stage);
        }

        // POST: Stages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stage = await _context.Stage.FindAsync(id);
            _context.Stage.Remove(stage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StageExists(int id)
        {
            return _context.Stage.Any(e => e.StageId == id);
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentId == id);
        }
    }
}
