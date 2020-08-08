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
    public class EvolucionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EvolucionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Evoluciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Evoluciones.Include(e => e.Medico);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Evoluciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evolucion = await _context.Evoluciones
                .Include(e => e.Medico)
                .FirstOrDefaultAsync(m => m.EvolucionId == id);
            if (evolucion == null)
            {
                return NotFound();
            }

            return View(evolucion);
        }

        // GET: Evoluciones/Create
        public IActionResult Create()
        {
            ViewData["CodEmpleado"] = new SelectList(_context.Set<Medico>(), "CodEmpleado", "CodEmpleado");
            return View();
        }

        // POST: Evoluciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvolucionId,CodEmpleado,HoraInicio,HoraFin,Descripcion,EstadoAbierto")] Evolucion evolucion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evolucion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodEmpleado"] = new SelectList(_context.Set<Medico>(), "CodEmpleado", "CodEmpleado", evolucion.CodEmpleado);
            return View(evolucion);
        }

        // GET: Evoluciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evolucion = await _context.Evoluciones.FindAsync(id);
            if (evolucion == null)
            {
                return NotFound();
            }
            ViewData["CodEmpleado"] = new SelectList(_context.Set<Medico>(), "CodEmpleado", "CodEmpleado", evolucion.CodEmpleado);
            return View(evolucion);
        }

        // POST: Evoluciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvolucionId,CodEmpleado,HoraInicio,HoraFin,Descripcion,EstadoAbierto")] Evolucion evolucion)
        {
            if (id != evolucion.EvolucionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evolucion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvolucionExists(evolucion.EvolucionId))
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
            ViewData["CodEmpleado"] = new SelectList(_context.Set<Medico>(), "CodEmpleado", "CodEmpleado", evolucion.CodEmpleado);
            return View(evolucion);
        }

        // GET: Evoluciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evolucion = await _context.Evoluciones
                .Include(e => e.Medico)
                .FirstOrDefaultAsync(m => m.EvolucionId == id);
            if (evolucion == null)
            {
                return NotFound();
            }

            return View(evolucion);
        }

        // POST: Evoluciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evolucion = await _context.Evoluciones.FindAsync(id);
            _context.Evoluciones.Remove(evolucion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvolucionExists(int id)
        {
            return _context.Evoluciones.Any(e => e.EvolucionId == id);
        }
    }
}
