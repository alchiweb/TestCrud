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
    public class VehiculeNewController : Controller
    {
        private readonly AlchiDbContext _context;
        private EntitySignalSubscribe _entitySignalSubscribe;

        public VehiculeNewController(AlchiDbContext context, EntitySignalSubscribe entitySignalSubscribe)
        {
            _context = context;
            _entitySignalSubscribe = entitySignalSubscribe;
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult<IEnumerable<VehiculeNew>> SubscribeToAll()
        {
            _entitySignalSubscribe.Subscribe<VehiculeNew>();
            return _context.VehiculeNew.ToList();
        }

        // GET: VehiculeNew
        public async Task<IActionResult> Index()
        {
            var alchiDbContext = _context.VehiculeNew.Include(v => v.Adresse).Include(v => v.CategorieVehicule).Include(v => v.TypePlanning).Include(v => v.TypeVehicule);
            return View(await alchiDbContext.ToListAsync());
        }

        // GET: VehiculeNew/Details/5
        public async Task<IActionResult> Details(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

           if (id == null)
            {
                return NotFound();
            }

            var vehiculeNew = await _context.VehiculeNew
                .Include(v => v.Adresse)
                .Include(v => v.CategorieVehicule)
                .Include(v => v.TypePlanning)
                .Include(v => v.TypeVehicule)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculeNew == null)
            {
                return NotFound();
            }

            return View(vehiculeNew);
        }

        // GET: VehiculeNew/Create
        public IActionResult Create(bool layout = true)
        {
            ViewBag.Layout = layout;

            ViewData["AdresseId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue");
ViewData["CategorieVehiculeId"] = new SelectList(_context.CategorieVehiculeNew, "Id", "DisplayValue");
ViewData["TypePlanningId"] = new SelectList(_context.TypePlanningNew, "Id", "DisplayValue");
ViewData["TypeVehiculeId"] = new SelectList(_context.TypeVehiculeNew, "Id", "DisplayValue");


            return View();
        }

        // POST: VehiculeNew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Immatriculation,VehiculeTexte,Libelle,Autoroute,Route,RouteSec,Tiers,Marque,MiseEnService,Acquisition,NoCg,Genre,TypeCg,NoSerie,Carrosserie,Notes,PoidsVide,Palette,Poids,MetrageLineaire,Volume,Longueur,Largeur,Hauteur,Ptac,DateSortie,PaysOrigine,Cabotage,DebutCabotage,DateCreation,DateSaisie,AdresseId,TypePlanningId,TypeVehiculeId,CategorieVehiculeId")] VehiculeNew vehiculeNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (ModelState.IsValid)
            {
                vehiculeNew.Id = Guid.NewGuid();
                try
                {
                    _context.Add(vehiculeNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (layout)
                    {
                        ViewBag.ErrorMessage = e.GetMessage();
                        return View(vehiculeNew);
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

            ViewData["AdresseId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue", vehiculeNew.AdresseId);
ViewData["CategorieVehiculeId"] = new SelectList(_context.CategorieVehiculeNew, "Id", "DisplayValue", vehiculeNew.CategorieVehiculeId);
ViewData["TypePlanningId"] = new SelectList(_context.TypePlanningNew, "Id", "DisplayValue", vehiculeNew.TypePlanningId);
ViewData["TypeVehiculeId"] = new SelectList(_context.TypeVehiculeNew, "Id", "DisplayValue", vehiculeNew.TypeVehiculeId);

            //if (!ModelState.IsValid)
            //    return ValidationProblem();
            return View(vehiculeNew);
        }

        // GET: VehiculeNew/Edit/5
        public async Task<IActionResult> Edit(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var vehiculeNew = await _context.VehiculeNew.FindAsync(id);
            if (vehiculeNew == null)
            {
                return NotFound();
            }

            ViewData["AdresseId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue", vehiculeNew.AdresseId);
ViewData["CategorieVehiculeId"] = new SelectList(_context.CategorieVehiculeNew, "Id", "DisplayValue", vehiculeNew.CategorieVehiculeId);
ViewData["TypePlanningId"] = new SelectList(_context.TypePlanningNew, "Id", "DisplayValue", vehiculeNew.TypePlanningId);
ViewData["TypeVehiculeId"] = new SelectList(_context.TypeVehiculeNew, "Id", "DisplayValue", vehiculeNew.TypeVehiculeId);


            return View(vehiculeNew);
        }

        // POST: VehiculeNew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Immatriculation,VehiculeTexte,Libelle,Autoroute,Route,RouteSec,Tiers,Marque,MiseEnService,Acquisition,NoCg,Genre,TypeCg,NoSerie,Carrosserie,Notes,PoidsVide,Palette,Poids,MetrageLineaire,Volume,Longueur,Largeur,Hauteur,Ptac,DateSortie,PaysOrigine,Cabotage,DebutCabotage,DateCreation,DateSaisie,AdresseId,TypePlanningId,TypeVehiculeId,CategorieVehiculeId")] VehiculeNew vehiculeNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id != vehiculeNew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculeNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (e is DbUpdateConcurrencyException && !VehiculeNewExists(vehiculeNew.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        if (layout)
                        {
                            ViewBag.ErrorMessage = e.GetMessage();
                            return View(vehiculeNew);
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

            ViewData["AdresseId"] = new SelectList(_context.AdresseNew, "Id", "DisplayValue", vehiculeNew.AdresseId);
ViewData["CategorieVehiculeId"] = new SelectList(_context.CategorieVehiculeNew, "Id", "DisplayValue", vehiculeNew.CategorieVehiculeId);
ViewData["TypePlanningId"] = new SelectList(_context.TypePlanningNew, "Id", "DisplayValue", vehiculeNew.TypePlanningId);
ViewData["TypeVehiculeId"] = new SelectList(_context.TypeVehiculeNew, "Id", "DisplayValue", vehiculeNew.TypeVehiculeId);


            return View(vehiculeNew);
        }

        // GET: VehiculeNew/Delete/5
        public async Task<IActionResult> Delete(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var vehiculeNew = await _context.VehiculeNew
                .Include(v => v.Adresse)
                .Include(v => v.CategorieVehicule)
                .Include(v => v.TypePlanning)
                .Include(v => v.TypeVehicule)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculeNew == null)
            {
                return NotFound();
            }

            return View(vehiculeNew);
        }

        // POST: VehiculeNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, bool layout = true)
        {
            ViewBag.Layout = layout;
            var vehiculeNew = await _context.VehiculeNew.FindAsync(id);

            try
            {
                _context.VehiculeNew.Remove(vehiculeNew);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (layout)
                {
                    ViewBag.ErrorMessage = e.GetMessage();
                    return View(vehiculeNew);
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

        private bool VehiculeNewExists(Guid id)
        {
            return _context.VehiculeNew.Any(e => e.Id == id);
        }
    }
}
