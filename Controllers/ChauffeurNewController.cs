using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EntitySignal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestCrud.Extensions;

using TestCrud.Data;
using TestCrud.Models;

namespace TestCrud.Controllers
{
    [Authorize]
    public class ChauffeurNewController : Controller
    {
        private readonly AlchiDbContext _context;
        private EntitySignalSubscribe _entitySignalSubscribe;

        public ChauffeurNewController(AlchiDbContext context, EntitySignalSubscribe entitySignalSubscribe)
        {
            _context = context;
            _entitySignalSubscribe = entitySignalSubscribe;
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult<IEnumerable<ChauffeurNew>> SubscribeToAll()
        {
            _entitySignalSubscribe.Subscribe<ChauffeurNew>();
            return _context.ChauffeurNew.ToList();
        }

        // GET: ChauffeurNew
        public async Task<IActionResult> Index()
        {
            var alchiDbContext = _context.ChauffeurNew.Include(c => c.Adresse).Include(c => c.AdresseChute).Include(c => c.Remorque).Include(c => c.TypePlanning).Include(c => c.Vehicule);
            return View(await alchiDbContext.ToListAsync());
        }

        // GET: ChauffeurNew/Details/5
        public async Task<IActionResult> Details(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

           if (id == null)
            {
                return NotFound();
            }

            var chauffeurNew = await _context.ChauffeurNew
                .Include(c => c.Adresse)
                .Include(c => c.AdresseChute)
                .Include(c => c.Remorque)
                .Include(c => c.TypePlanning)
                .Include(c => c.Vehicule)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chauffeurNew == null)
            {
                return NotFound();
            }

            return View(chauffeurNew);
        }

        // GET: ChauffeurNew/Create
        public IActionResult Create(bool layout = true)
        {
            ViewBag.Layout = layout;

            ViewData["AdresseId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue");
ViewData["AdresseChuteId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue");
ViewData["RemorqueId"] = new SelectList(_context.VehiculeNew, "Id", "DisplayValue");
ViewData["TypePlanningId"] = new SelectList(_context.TypePlanningNew, "Id", "DisplayValue");
ViewData["VehiculeId"] = new SelectList(_context.VehiculeNew, "Id", "DisplayValue");


            return View();
        }

        // POST: ChauffeurNew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Operateur,Abrege,Nom,Prenom,Telephone,Telephone2,Portable,Email,Permis,NbHeures,Notes,Tiers,DateSortie,DateCreation,DateSaisie,AdresseId,AdresseChuteId,VehiculeId,RemorqueId,TypePlanningId")] ChauffeurNew chauffeurNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (ModelState.IsValid)
            {
                chauffeurNew.Id = Guid.NewGuid();
                try
                {
                    _context.Add(chauffeurNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (layout)
                    {
                        ViewBag.ErrorMessage = e.GetMessage();
                        return View(chauffeurNew);
                    }
                    else
                    {
                        return StatusCode((int)HttpStatusCode.InternalServerError, Json(e.GetMessage()));
                    }
                }
                if (layout)
                    return RedirectToAction(nameof(Index));
                return NoContent();
            }

            ViewData["AdresseId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue", chauffeurNew.AdresseId);
ViewData["AdresseChuteId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue", chauffeurNew.AdresseChuteId);
ViewData["RemorqueId"] = new SelectList(_context.VehiculeNew, "Id", "DisplayValue", chauffeurNew.RemorqueId);
ViewData["TypePlanningId"] = new SelectList(_context.TypePlanningNew, "Id", "DisplayValue", chauffeurNew.TypePlanningId);
ViewData["VehiculeId"] = new SelectList(_context.VehiculeNew, "Id", "DisplayValue", chauffeurNew.VehiculeId);


            return View(chauffeurNew);
        }

        // GET: ChauffeurNew/Edit/5
        public async Task<IActionResult> Edit(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var chauffeurNew = await _context.ChauffeurNew.FindAsync(id);
            if (chauffeurNew == null)
            {
                return NotFound();
            }

            ViewData["AdresseId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue", chauffeurNew.AdresseId);
ViewData["AdresseChuteId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue", chauffeurNew.AdresseChuteId);
ViewData["RemorqueId"] = new SelectList(_context.VehiculeNew, "Id", "DisplayValue", chauffeurNew.RemorqueId);
ViewData["TypePlanningId"] = new SelectList(_context.TypePlanningNew, "Id", "DisplayValue", chauffeurNew.TypePlanningId);
ViewData["VehiculeId"] = new SelectList(_context.VehiculeNew, "Id", "DisplayValue", chauffeurNew.VehiculeId);


            return View(chauffeurNew);
        }

        // POST: ChauffeurNew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Operateur,Abrege,Nom,Prenom,Telephone,Telephone2,Portable,Email,Permis,NbHeures,Notes,Tiers,DateSortie,DateCreation,DateSaisie,AdresseId,AdresseChuteId,VehiculeId,RemorqueId,TypePlanningId")] ChauffeurNew chauffeurNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id != chauffeurNew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chauffeurNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (e is DbUpdateConcurrencyException && !ChauffeurNewExists(chauffeurNew.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        if (layout)
                        {
                            ViewBag.ErrorMessage = e.GetMessage();
                            return View(chauffeurNew);
                        }
                        else
                        {
                            return StatusCode((int)HttpStatusCode.InternalServerError, Json(e.GetMessage()));
                        }
                    }
                }
                if (layout)
                    return RedirectToAction(nameof(Index));
                return NoContent();
            }

            ViewData["AdresseId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue", chauffeurNew.AdresseId);
ViewData["AdresseChuteId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue", chauffeurNew.AdresseChuteId);
ViewData["RemorqueId"] = new SelectList(_context.VehiculeNew, "Id", "DisplayValue", chauffeurNew.RemorqueId);
ViewData["TypePlanningId"] = new SelectList(_context.TypePlanningNew, "Id", "DisplayValue", chauffeurNew.TypePlanningId);
ViewData["VehiculeId"] = new SelectList(_context.VehiculeNew, "Id", "DisplayValue", chauffeurNew.VehiculeId);


            return View(chauffeurNew);
        }

        // GET: ChauffeurNew/Delete/5
        public async Task<IActionResult> Delete(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var chauffeurNew = await _context.ChauffeurNew
                .Include(c => c.Adresse)
                .Include(c => c.AdresseChute)
                .Include(c => c.Remorque)
                .Include(c => c.TypePlanning)
                .Include(c => c.Vehicule)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chauffeurNew == null)
            {
                return NotFound();
            }

            return View(chauffeurNew);
        }

        // POST: ChauffeurNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, bool layout = true)
        {
            ViewBag.Layout = layout;
            var chauffeurNew = await _context.ChauffeurNew.FindAsync(id);

            try
            {
                _context.ChauffeurNew.Remove(chauffeurNew);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (layout)
                {
                    ViewBag.ErrorMessage = e.GetMessage();
                    return View(chauffeurNew);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, Json(e.GetMessage()));
                }
            }
            if (layout)
                return RedirectToAction(nameof(Index));
            return NoContent();
        }

        private bool ChauffeurNewExists(Guid id)
        {
            return _context.ChauffeurNew.Any(e => e.Id == id);
        }
    }
}
