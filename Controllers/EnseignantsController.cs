using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pfe.Data;
using pfe.Models;

namespace pfe.Controllers
{
    public class EnseignantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger _logger;

        public EnseignantsController(ApplicationDbContext context, UserManager<ApplicationUser> userManger, RoleManager<IdentityRole> roleManager, ILogger<StudentsController> logger)
        {
            _context = context;
            _userManager = userManger;

            _roleManager = roleManager;
            _logger = logger;
        }
        // GET: Enseignants


  /*      [Authorize(Roles = "enseignant")]*/



        public async Task<IActionResult> Index(string sortOrder,
   string searchString)
        {

            /* var applicationDbContext = _context.Enseignant.Include(s => s.Stages);*/

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            /* ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";*/


            ViewData["CurrentFilter"] = searchString;

            var enseignants = from s in _context.Enseignant
                              select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                enseignants = enseignants.Where(s => s.Nom.Contains(searchString)
                                       || s.Prenom.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    enseignants = enseignants.OrderByDescending(s => s.Nom);
                    break;

                default:
                    enseignants = enseignants.OrderBy(s => s.Prenom);
                    break;
            }


            return View(await _context.Enseignant.ToListAsync());
            /*   return View(await PaginatedList4Enseign<Enseignant>.CreateAsync(enseignants.AsNoTracking(), pageNumber ?? 1, pageSize));
   */
        }

        // GET: Enseignants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var enseignant = await _context.Enseignant
             .Include(s => s.Stages)

             .AsNoTracking()
            .FirstOrDefaultAsync(m => m.EnseignantId == id);


            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // GET: Enseignants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enseignants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("EnseignantId,Nom,Prenom,Email,Cin")] Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enseignant);
                await _context.SaveChangesAsync();


                var user = new ApplicationUser { UserName = enseignant.Email, Email = enseignant.Email, UserId = enseignant.EnseignantId.ToString(), EmailConfirmed = true };


                var result = await _userManager.CreateAsync(user, enseignant.Nom + "@" + enseignant.Cin);


                var role = _roleManager.FindByIdAsync("a8e92e27-a40b-4d9a-b0a1-24c6591c7a8a").Result;



                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    await _userManager.AddToRoleAsync(user, role.Name);

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }




                return RedirectToAction(nameof(Index));



            }
            return View(enseignant);
        }

        // GET: Enseignants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignant.FindAsync(id);
            if (enseignant == null)
            {
                return NotFound();
            }
            return View(enseignant);
        }

        // POST: Enseignants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnseignantId,Nom,Prenom,Email")] Enseignant enseignant)
        {
            if (id != enseignant.EnseignantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enseignant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnseignantExists(enseignant.EnseignantId))
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
            return View(enseignant);
        }

        // GET: Enseignants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignant
                .FirstOrDefaultAsync(m => m.EnseignantId == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // POST: Enseignants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enseignant = await _context.Enseignant.FindAsync(id);
            _context.Enseignant.Remove(enseignant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnseignantExists(int id)
        {
            return _context.Enseignant.Any(e => e.EnseignantId == id);
        }
    }
}
