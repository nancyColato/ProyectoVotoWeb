using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVotoWeb.Data;
using ProyectoVotoWeb.Models;

namespace ProyectoVotoWeb.Controllers
{
    public class HorariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HorariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {

          ViewBag.Restaurante = await _context.tblRestaurante.ToListAsync();
          return View(await _context.tblHorario.ToListAsync());
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
          //llamadaa tblRestaurante y envio a vista
          ViewData["IdRestaurante"] = new SelectList(_context.tblRestaurante, "IdRestaurante", "NombreRestaurante");
          return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHorario,HoraApertura,HoraCierre,DiaInicio,DiaFin,IdRestaurante")] tblHorarios tblHorarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblHorarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //llamadaa tblRestaurante y envio a vista
            ViewData["IdRestaurante"] = new SelectList(_context.tblRestaurante, "IdRestaurante", "NombreRestaurante");

            return View(tblHorarios);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHorarios = await _context.tblHorario.FindAsync(id);
            if (tblHorarios == null)
            {
                return NotFound();
            }
            //llamadaa tblRestaurante y envio a vista
            ViewData["idRestaurante"] = new SelectList(_context.tblRestaurante, "IdRestaurante", "NombreRestaurante");

            return View(tblHorarios);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHorario,HoraApertura,HoraCierre,DiaInicio,DiaFin,IdRestaurante")] tblHorarios tblHorarios)
        {
            if (id != tblHorarios.IdHorario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblHorarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblHorariosExists(tblHorarios.IdHorario))
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
            return View(tblHorarios);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblHorarios = await _context.tblHorario
                .FirstOrDefaultAsync(m => m.IdHorario == id);
            if (tblHorarios == null)
            {
                return NotFound();
            }

            return View(tblHorarios);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblHorarios = await _context.tblHorario.FindAsync(id);
            _context.tblHorario.Remove(tblHorarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblHorariosExists(int id)
        {
            return _context.tblHorario.Any(e => e.IdHorario == id);
        }
    }
}
