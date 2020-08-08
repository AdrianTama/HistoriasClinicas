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
    public class HistoriasClinicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoriasClinicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HistoriasClinicas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HistoriasClinicas.Include(h => h.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HistoriasClinicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriasClinicas
                .Include(h => h.Paciente)
                .FirstOrDefaultAsync(m => m.HistoriaClinicaId == id);
            if (historiaClinica == null)
            {
                return NotFound();
            }

            return View(historiaClinica);
        }

        // GET: HistoriasClinicas/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Apellido");
            return View();
        }

        // POST: HistoriasClinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoriaClinicaId,PacienteId")] HistoriaClinica historiaClinica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historiaClinica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Apellido", historiaClinica.PacienteId);
            return View(historiaClinica);
        }

        // GET: HistoriasClinicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriasClinicas.FindAsync(id);
            if (historiaClinica == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Apellido", historiaClinica.PacienteId);
            return View(historiaClinica);
        }

        // POST: HistoriasClinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoriaClinicaId,PacienteId")] HistoriaClinica historiaClinica)
        {
            if (id != historiaClinica.HistoriaClinicaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historiaClinica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaClinicaExists(historiaClinica.HistoriaClinicaId))
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
            ViewData["PacienteId"] = new SelectList(_context.Set<Paciente>(), "PacienteId", "Apellido", historiaClinica.PacienteId);
            return View(historiaClinica);
        }

        // GET: HistoriasClinicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriasClinicas
                .Include(h => h.Paciente)
                .FirstOrDefaultAsync(m => m.HistoriaClinicaId == id);
            if (historiaClinica == null)
            {
                return NotFound();
            }

            return View(historiaClinica);
        }

        // POST: HistoriasClinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historiaClinica = await _context.HistoriasClinicas.FindAsync(id);
            _context.HistoriasClinicas.Remove(historiaClinica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaClinicaExists(int id)
        {
            return _context.HistoriasClinicas.Any(e => e.HistoriaClinicaId == id);
        }
    }
}
