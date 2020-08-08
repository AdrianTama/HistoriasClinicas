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
    public class AdministrativosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministrativosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administrativos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Administrativos.ToListAsync());
        }

        // GET: Administrativos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativo = await _context.Administrativos
                .FirstOrDefaultAsync(m => m.CodEmpleado == id);
            if (administrativo == null)
            {
                return NotFound();
            }

            return View(administrativo);
        }

        // GET: Administrativos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrativos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodEmpleado,Dni,Nombre,Apellido,Nacimiento,Email,Telefono")] Administrativo administrativo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrativo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administrativo);
        }

        // GET: Administrativos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativo = await _context.Administrativos.FindAsync(id);
            if (administrativo == null)
            {
                return NotFound();
            }
            return View(administrativo);
        }

        // POST: Administrativos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodEmpleado,Dni,Nombre,Apellido,Nacimiento,Email,Telefono")] Administrativo administrativo)
        {
            if (id != administrativo.CodEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrativo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrativoExists(administrativo.CodEmpleado))
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
            return View(administrativo);
        }

        // GET: Administrativos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativo = await _context.Administrativos
                .FirstOrDefaultAsync(m => m.CodEmpleado == id);
            if (administrativo == null)
            {
                return NotFound();
            }

            return View(administrativo);
        }

        // POST: Administrativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var administrativo = await _context.Administrativos.FindAsync(id);
            _context.Administrativos.Remove(administrativo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrativoExists(string id)
        {
            return _context.Administrativos.Any(e => e.CodEmpleado == id);
        }
    }
}
