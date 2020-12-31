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
    public class TypePlanningNewController : Controller
    {
        private readonly AlchiDbContext _context;
        private EntitySignalSubscribe _entitySignalSubscribe;

        public TypePlanningNewController(AlchiDbContext context, EntitySignalSubscribe entitySignalSubscribe)
        {
            _context = context;
            _entitySignalSubscribe = entitySignalSubscribe;
        }

        [HttpGet]
        [ResponseCache(NoStore = true, Duration = 0)]
        public ActionResult<IEnumerable<TypePlanningNew>> SubscribeToAll()
        {
            _entitySignalSubscribe.Subscribe<TypePlanningNew>();
            return _context.TypePlanningNew.ToList();
        }

        // GET: TypePlanningNew
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypePlanningNew.ToListAsync());
        }

        // GET: TypePlanningNew/Details/5
        public async Task<IActionResult> Details(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

           if (id == null)
            {
                return NotFound();
            }

            var typePlanningNew = await _context.TypePlanningNew
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typePlanningNew == null)
            {
                return NotFound();
            }

            return View(typePlanningNew);
        }

        // GET: TypePlanningNew/Create
        public IActionResult Create(bool layout = true)
        {
            ViewBag.Layout = layout;

            

            return View();
        }

        // POST: TypePlanningNew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypePlanningTexte,Libelle,ActiviteAnalytique,GenereDemandePrix")] TypePlanningNew typePlanningNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (ModelState.IsValid)
            {
                typePlanningNew.Id = Guid.NewGuid();
                try
                {
                    _context.Add(typePlanningNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (layout)
                    {
                        ViewBag.ErrorMessage = e.GetMessage();
                        return View(typePlanningNew);
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

            

            return View(typePlanningNew);
        }

        // GET: TypePlanningNew/Edit/5
        public async Task<IActionResult> Edit(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var typePlanningNew = await _context.TypePlanningNew.FindAsync(id);
            if (typePlanningNew == null)
            {
                return NotFound();
            }

            

            return View(typePlanningNew);
        }

        // POST: TypePlanningNew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TypePlanningTexte,Libelle,ActiviteAnalytique,GenereDemandePrix")] TypePlanningNew typePlanningNew, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id != typePlanningNew.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typePlanningNew);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    if (e is DbUpdateConcurrencyException && !TypePlanningNewExists(typePlanningNew.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        if (layout)
                        {
                            ViewBag.ErrorMessage = e.GetMessage();
                            return View(typePlanningNew);
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

            

            return View(typePlanningNew);
        }

        // GET: TypePlanningNew/Delete/5
        public async Task<IActionResult> Delete(Guid? id, bool layout = true)
        {
            ViewBag.Layout = layout;

            if (id == null)
            {
                return NotFound();
            }

            var typePlanningNew = await _context.TypePlanningNew
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typePlanningNew == null)
            {
                return NotFound();
            }

            return View(typePlanningNew);
        }

        // POST: TypePlanningNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, bool layout = true)
        {
            ViewBag.Layout = layout;
            var typePlanningNew = await _context.TypePlanningNew.FindAsync(id);

            try
            {
                _context.TypePlanningNew.Remove(typePlanningNew);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (layout)
                {
                    ViewBag.ErrorMessage = e.GetMessage();
                    return View(typePlanningNew);
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

        private bool TypePlanningNewExists(Guid id)
        {
            return _context.TypePlanningNew.Any(e => e.Id == id);
        }
    }
}
