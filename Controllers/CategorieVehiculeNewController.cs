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
    public class CategorieVehiculeNewController : Controller
    {
        private readonly AlchiDbContext _context;
        private EntitySignalSubscribe _entitySignalSubscribe;

        public CategorieVehiculeNewController(AlchiDbContext context, EntitySignalSubscribe entitySignalSubscribe)
        {
            _context = context;
            _entitySignalSubscribe = entitySignalSubscribe;
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult<IEnumerable<CategorieVehiculeNew>> SubscribeToAll()
        {
            _entitySignalSubscribe.Subscribe<CategorieVehiculeNew>();
            return _context.CategorieVehiculeNew.ToList();
        }

        // GET: CategorieVehiculeNew
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategorieVehiculeNew.ToListAsync());
        }

        // GET: CategorieVehiculeNew/Details/5
        public async Task<IActionResult> Details(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

           if (id == null)
            {
                return NotFound();
            }

            var categorieVehiculeNew = await _context.CategorieVehiculeNew
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorieVehiculeNew == null)
            {
                return NotFound();
            }

            return View(categorieVehiculeNew);
        }

        // GET: CategorieVehiculeNew/Create
        public IActionResult Create(bool layout = true)
        {
            ViewBag.Layout = layout;

            

            return View();
        }

        // POST: CategorieVehiculeNew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Categorie,Libelle,DateCreation,DateSaisie")] CategorieVehiculeNew categorieVehiculeNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (ModelState.IsValid)
            {
                categorieVehiculeNew.Id = Guid.NewGuid();
                try
                {
                    _context.Add(categorieVehiculeNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (layout)
                    {
                        ViewBag.ErrorMessage = e.GetMessage();
                        return View(categorieVehiculeNew);
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

            

            return View(categorieVehiculeNew);
        }

        // GET: CategorieVehiculeNew/Edit/5
        public async Task<IActionResult> Edit(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var categorieVehiculeNew = await _context.CategorieVehiculeNew.FindAsync(id);
            if (categorieVehiculeNew == null)
            {
                return NotFound();
            }

            

            return View(categorieVehiculeNew);
        }

        // POST: CategorieVehiculeNew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Categorie,Libelle,DateCreation,DateSaisie")] CategorieVehiculeNew categorieVehiculeNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id != categorieVehiculeNew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorieVehiculeNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (e is DbUpdateConcurrencyException && !CategorieVehiculeNewExists(categorieVehiculeNew.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        if (layout)
                        {
                            ViewBag.ErrorMessage = e.GetMessage();
                            return View(categorieVehiculeNew);
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

            

            return View(categorieVehiculeNew);
        }

        // GET: CategorieVehiculeNew/Delete/5
        public async Task<IActionResult> Delete(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var categorieVehiculeNew = await _context.CategorieVehiculeNew
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorieVehiculeNew == null)
            {
                return NotFound();
            }

            return View(categorieVehiculeNew);
        }

        // POST: CategorieVehiculeNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, bool layout = true)
        {
            ViewBag.Layout = layout;
            var categorieVehiculeNew = await _context.CategorieVehiculeNew.FindAsync(id);

            try
            {
                _context.CategorieVehiculeNew.Remove(categorieVehiculeNew);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (layout)
                {
                    ViewBag.ErrorMessage = e.GetMessage();
                    return View(categorieVehiculeNew);
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

        private bool CategorieVehiculeNewExists(Guid id)
        {
            return _context.CategorieVehiculeNew.Any(e => e.Id == id);
        }
    }
}
