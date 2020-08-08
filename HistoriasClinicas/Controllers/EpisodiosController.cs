﻿using System;
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
    public class EpisodiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EpisodiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Episodios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Episodios.Include(e => e.Epicrisis);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Episodios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episodio = await _context.Episodios
                .Include(e => e.Epicrisis)
                .FirstOrDefaultAsync(m => m.EpisodioId == id);
            if (episodio == null)
            {
                return NotFound();
            }

            return View(episodio);
        }

        // GET: Episodios/Create
        public IActionResult Create()
        {
            ViewData["EpicrisisId"] = new SelectList(_context.Epicrisis, "EpicrisisId", "Diagnostico");
            return View();
        }

        // POST: Episodios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EpisodioId,Motivo,Descripcion,EstadoAbierto,EpicrisisId")] Episodio episodio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(episodio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EpicrisisId"] = new SelectList(_context.Epicrisis, "EpicrisisId", "Diagnostico", episodio.EpicrisisId);
            return View(episodio);
        }

        // GET: Episodios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episodio = await _context.Episodios.FindAsync(id);
            if (episodio == null)
            {
                return NotFound();
            }
            ViewData["EpicrisisId"] = new SelectList(_context.Epicrisis, "EpicrisisId", "Diagnostico", episodio.EpicrisisId);
            return View(episodio);
        }

        // POST: Episodios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EpisodioId,Motivo,Descripcion,EstadoAbierto,EpicrisisId")] Episodio episodio)
        {
            if (id != episodio.EpisodioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(episodio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpisodioExists(episodio.EpisodioId))
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
            ViewData["EpicrisisId"] = new SelectList(_context.Epicrisis, "EpicrisisId", "Diagnostico", episodio.EpicrisisId);
            return View(episodio);
        }

        // GET: Episodios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var episodio = await _context.Episodios
                .Include(e => e.Epicrisis)
                .FirstOrDefaultAsync(m => m.EpisodioId == id);
            if (episodio == null)
            {
                return NotFound();
            }

            return View(episodio);
        }

        // POST: Episodios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var episodio = await _context.Episodios.FindAsync(id);
            _context.Episodios.Remove(episodio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpisodioExists(int id)
        {
            return _context.Episodios.Any(e => e.EpisodioId == id);
        }
    }
}