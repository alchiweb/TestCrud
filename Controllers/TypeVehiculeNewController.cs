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
    public class TypeVehiculeNewController : Controller
    {
        private readonly AlchiDbContext _context;
        private EntitySignalSubscribe _entitySignalSubscribe;

        public TypeVehiculeNewController(AlchiDbContext context, EntitySignalSubscribe entitySignalSubscribe)
        {
            _context = context;
            _entitySignalSubscribe = entitySignalSubscribe;
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult<IEnumerable<TypeVehiculeNew>> SubscribeToAll()
        {
            _entitySignalSubscribe.Subscribe<TypeVehiculeNew>();
            return _context.TypeVehiculeNew.ToList();
        }

        // GET: TypeVehiculeNew
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeVehiculeNew.ToListAsync());
        }

        // GET: TypeVehiculeNew/Details/5
        public async Task<IActionResult> Details(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

           if (id == null)
            {
                return NotFound();
            }

            var typeVehiculeNew = await _context.TypeVehiculeNew
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeVehiculeNew == null)
            {
                return NotFound();
            }

            return View(typeVehiculeNew);
        }

        // GET: TypeVehiculeNew/Create
        public IActionResult Create(bool layout = true)
        {
            ViewBag.Layout = layout;

            

            return View();
        }

        // POST: TypeVehiculeNew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeVehiculeTexte,Libelle,Remorque,Camion,Tracteur,SousTraitant,Autoroute,Route,RouteSec,DateCreation,DateSaisie")] TypeVehiculeNew typeVehiculeNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (ModelState.IsValid)
            {
                typeVehiculeNew.Id = Guid.NewGuid();
                try
                {
                    _context.Add(typeVehiculeNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (layout)
                    {
                        ViewBag.ErrorMessage = e.GetMessage();
                        return View(typeVehiculeNew);
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

            

            return View(typeVehiculeNew);
        }

        // GET: TypeVehiculeNew/Edit/5
        public async Task<IActionResult> Edit(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var typeVehiculeNew = await _context.TypeVehiculeNew.FindAsync(id);
            if (typeVehiculeNew == null)
            {
                return NotFound();
            }

            

            return View(typeVehiculeNew);
        }

        // POST: TypeVehiculeNew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TypeVehiculeTexte,Libelle,Remorque,Camion,Tracteur,SousTraitant,Autoroute,Route,RouteSec,DateCreation,DateSaisie")] TypeVehiculeNew typeVehiculeNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id != typeVehiculeNew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeVehiculeNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (e is DbUpdateConcurrencyException && !TypeVehiculeNewExists(typeVehiculeNew.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        if (layout)
                        {
                            ViewBag.ErrorMessage = e.GetMessage();
                            return View(typeVehiculeNew);
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

            

            return View(typeVehiculeNew);
        }

        // GET: TypeVehiculeNew/Delete/5
        public async Task<IActionResult> Delete(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var typeVehiculeNew = await _context.TypeVehiculeNew
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeVehiculeNew == null)
            {
                return NotFound();
            }

            return View(typeVehiculeNew);
        }

        // POST: TypeVehiculeNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, bool layout = true)
        {
            ViewBag.Layout = layout;
            var typeVehiculeNew = await _context.TypeVehiculeNew.FindAsync(id);

            try
            {
                _context.TypeVehiculeNew.Remove(typeVehiculeNew);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (layout)
                {
                    ViewBag.ErrorMessage = e.GetMessage();
                    return View(typeVehiculeNew);
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

        private bool TypeVehiculeNewExists(Guid id)
        {
            return _context.TypeVehiculeNew.Any(e => e.Id == id);
        }
    }
}
