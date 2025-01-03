﻿using System;
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
    public class AgendaClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgendaClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AgendaClientes
        public async Task<IActionResult> Index()
        {
              return _context.AgendaClientes != null ? 
                          View(await _context.AgendaClientes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AgendaClientes'  is null.");
        }

        // GET: AgendaClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AgendaClientes == null)
            {
                return NotFound();
            }

            var agendaCliente = await _context.AgendaClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendaCliente == null)
            {
                return NotFound();
            }

            return View(agendaCliente);
        }

        // GET: AgendaClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgendaClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Proyecto,Empresa,Telefono,Correo,FechaDeIngreso,HoraDeAgenda,FechaHoraAtencionOficina")] AgendaCliente agendaCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agendaCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agendaCliente);
        }

        // GET: AgendaClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AgendaClientes == null)
            {
                return NotFound();
            }

            var agendaCliente = await _context.AgendaClientes.FindAsync(id);
            if (agendaCliente == null)
            {
                return NotFound();
            }
            return View(agendaCliente);
        }

        // POST: AgendaClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Proyecto,Empresa,Telefono,Correo,FechaDeIngreso,HoraDeAgenda,FechaHoraAtencionOficina")] AgendaCliente agendaCliente)
        {
            if (id != agendaCliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agendaCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaClienteExists(agendaCliente.Id))
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
            return View(agendaCliente);
        }

        // GET: AgendaClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AgendaClientes == null)
            {
                return NotFound();
            }

            var agendaCliente = await _context.AgendaClientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agendaCliente == null)
            {
                return NotFound();
            }

            return View(agendaCliente);
        }

        // POST: AgendaClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AgendaClientes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AgendaClientes'  is null.");
            }
            var agendaCliente = await _context.AgendaClientes.FindAsync(id);
            if (agendaCliente != null)
            {
                _context.AgendaClientes.Remove(agendaCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgendaClienteExists(int id)
        {
          return (_context.AgendaClientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
