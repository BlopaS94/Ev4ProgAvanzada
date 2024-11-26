using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ev4ProgAvanzada.Data;
using Ev4ProgAvanzada.Models;

namespace Ev4ProgAvanzada.Controllers
{
    public class AgentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Agentes
        public async Task<IActionResult> Index()
        {
              return _context.Agentes != null ? 
                          View(await _context.Agentes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Agentes'  is null.");
        }

        // GET: Agentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Agentes == null)
            {
                return NotFound();
            }

            var agente = await _context.Agentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agente == null)
            {
                return NotFound();
            }

            return View(agente);
        }

        // GET: Agentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Email,Telefono,EnOficina")] Agente agente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agente);
        }

        // GET: Agentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Agentes == null)
            {
                return NotFound();
            }

            var agente = await _context.Agentes.FindAsync(id);
            if (agente == null)
            {
                return NotFound();
            }
            return View(agente);
        }

        // POST: Agentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Email,Telefono,EnOficina")] Agente agente)
        {
            if (id != agente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgenteExists(agente.Id))
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
            return View(agente);
        }

        // GET: Agentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Agentes == null)
            {
                return NotFound();
            }

            var agente = await _context.Agentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agente == null)
            {
                return NotFound();
            }

            return View(agente);
        }

        // POST: Agentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Agentes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Agentes'  is null.");
            }
            var agente = await _context.Agentes.FindAsync(id);
            if (agente != null)
            {
                _context.Agentes.Remove(agente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgenteExists(int id)
        {
          return (_context.Agentes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
