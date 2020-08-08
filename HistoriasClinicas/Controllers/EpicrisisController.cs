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
    public class EpicrisisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EpicrisisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Epicrisis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Epicrisis.ToListAsync());
        }

        // GET: Epicrisis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epicrisis = await _context.Epicrisis
                .FirstOrDefaultAsync(m => m.EpicrisisId == id);
            if (epicrisis == null)
            {
                return NotFound();
            }

            return View(epicrisis);
        }

        // GET: Epicrisis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Epicrisis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EpicrisisId,HistoricaClinicaId,HoraCarga,Diagnostico")] Epicrisis epicrisis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(epicrisis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(epicrisis);
        }

        // GET: Epicrisis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epicrisis = await _context.Epicrisis.FindAsync(id);
            if (epicrisis == null)
            {
                return NotFound();
            }
            return View(epicrisis);
        }

        // POST: Epicrisis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EpicrisisId,HistoricaClinicaId,HoraCarga,Diagnostico")] Epicrisis epicrisis)
        {
            if (id != epicrisis.EpicrisisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(epicrisis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpicrisisExists(epicrisis.EpicrisisId))
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
            return View(epicrisis);
        }

        // GET: Epicrisis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var epicrisis = await _context.Epicrisis
                .FirstOrDefaultAsync(m => m.EpicrisisId == id);
            if (epicrisis == null)
            {
                return NotFound();
            }

            return View(epicrisis);
        }

        // POST: Epicrisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var epicrisis = await _context.Epicrisis.FindAsync(id);
            _context.Epicrisis.Remove(epicrisis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpicrisisExists(int id)
        {
            return _context.Epicrisis.Any(e => e.EpicrisisId == id);
        }
    }
}
