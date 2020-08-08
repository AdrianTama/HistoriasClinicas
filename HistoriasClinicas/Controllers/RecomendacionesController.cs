using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HistoriasClinicas.Data;
using HistoriasClinicas.Models;

namespace HistoriasClinicas.Controllers
{
    public class RecomendacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecomendacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recomendaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recomendaciones.ToListAsync());
        }

        // GET: Recomendaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendacion = await _context.Recomendaciones
                .FirstOrDefaultAsync(m => m.RecomendacionId == id);
            if (recomendacion == null)
            {
                return NotFound();
            }

            return View(recomendacion);
        }

        // GET: Recomendaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recomendaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecomendacionId,Descripcion")] Recomendacion recomendacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recomendacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recomendacion);
        }

        // GET: Recomendaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendacion = await _context.Recomendaciones.FindAsync(id);
            if (recomendacion == null)
            {
                return NotFound();
            }
            return View(recomendacion);
        }

        // POST: Recomendaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecomendacionId,Descripcion")] Recomendacion recomendacion)
        {
            if (id != recomendacion.RecomendacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recomendacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecomendacionExists(recomendacion.RecomendacionId))
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
            return View(recomendacion);
        }

        // GET: Recomendaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendacion = await _context.Recomendaciones
                .FirstOrDefaultAsync(m => m.RecomendacionId == id);
            if (recomendacion == null)
            {
                return NotFound();
            }

            return View(recomendacion);
        }

        // POST: Recomendaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recomendacion = await _context.Recomendaciones.FindAsync(id);
            _context.Recomendaciones.Remove(recomendacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecomendacionExists(int id)
        {
            return _context.Recomendaciones.Any(e => e.RecomendacionId == id);
        }
    }
}
