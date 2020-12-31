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
    public class AdresseNewController : Controller
    {
        private readonly AlchiDbContext _context;
        private EntitySignalSubscribe _entitySignalSubscribe;

        public AdresseNewController(AlchiDbContext context, EntitySignalSubscribe entitySignalSubscribe)
        {
            _context = context;
            _entitySignalSubscribe = entitySignalSubscribe;
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult<IEnumerable<AdresseNew>> SubscribeToAll()
        {
            _entitySignalSubscribe.Subscribe<AdresseNew>();
            return _context.AdresseNew.ToList();
        }

        // GET: AdresseNew
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdresseNew.ToListAsync());
        }

        // GET: AdresseNew/Details/5
        public async Task<IActionResult> Details(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

           if (id == null)
            {
                return NotFound();
            }

            var adresseNew = await _context.AdresseNew
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adresseNew == null)
            {
                return NotFound();
            }

            return View(adresseNew);
        }

        // GET: AdresseNew/Create
        public IActionResult Create(bool layout = true)
        {
            ViewBag.Layout = layout;

            

            return View();
        }

        // POST: AdresseNew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdresseTexte,Complement,CodePostal,Ville,NomVille,Departement,NomDepartement,Region,NomRegion,Pays,NomPays")] AdresseNew adresseNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (ModelState.IsValid)
            {
                adresseNew.Id = Guid.NewGuid();
                try
                {
                    _context.Add(adresseNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (layout)
                    {
                        ViewBag.ErrorMessage = e.GetMessage();
                        return View(adresseNew);
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

            

            return View(adresseNew);
        }

        // GET: AdresseNew/Edit/5
        public async Task<IActionResult> Edit(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var adresseNew = await _context.AdresseNew.FindAsync(id);
            if (adresseNew == null)
            {
                return NotFound();
            }

            

            return View(adresseNew);
        }

        // POST: AdresseNew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,AdresseTexte,Complement,CodePostal,Ville,NomVille,Departement,NomDepartement,Region,NomRegion,Pays,NomPays")] AdresseNew adresseNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id != adresseNew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adresseNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (e is DbUpdateConcurrencyException && !AdresseNewExists(adresseNew.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        if (layout)
                        {
                            ViewBag.ErrorMessage = e.GetMessage();
                            return View(adresseNew);
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

            

            return View(adresseNew);
        }

        // GET: AdresseNew/Delete/5
        public async Task<IActionResult> Delete(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var adresseNew = await _context.AdresseNew
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adresseNew == null)
            {
                return NotFound();
            }

            return View(adresseNew);
        }

        // POST: AdresseNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, bool layout = true)
        {
            ViewBag.Layout = layout;
            var adresseNew = await _context.AdresseNew.FindAsync(id);

            try
            {
                _context.AdresseNew.Remove(adresseNew);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (layout)
                {
                    ViewBag.ErrorMessage = e.GetMessage();
                    return View(adresseNew);
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

        private bool AdresseNewExists(Guid id)
        {
            return _context.AdresseNew.Any(e => e.Id == id);
        }
    }
}
