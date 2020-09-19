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
    public class VotacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VotacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Votaciones
        public async Task<IActionResult> Index()
        {
            ViewBag.Restaurante = await _context.tblRestaurante.ToListAsync();//datos sobre restaurante

            return View(await _context.tblVotacion.ToListAsync());
        }

        

        // GET: Votaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVotaciones = await _context.tblVotacion
                .FirstOrDefaultAsync(m => m.IdVoto == id);
            if (tblVotaciones == null)
            {
                return NotFound();
            }

            return View(tblVotaciones);
        }

        // POST: Votaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblVotaciones = await _context.tblVotacion.FindAsync(id);
            _context.tblVotacion.Remove(tblVotaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblVotacionesExists(int id)
        {
            return _context.tblVotacion.Any(e => e.IdVoto == id);
        }
    }
}
