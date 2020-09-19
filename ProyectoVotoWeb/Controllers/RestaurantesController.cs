using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoVotoWeb.Data;
using ProyectoVotoWeb.Models;

namespace ProyectoVotoWeb.Controllers
{
    public class RestaurantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RestaurantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Restaurantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblRestaurante.ToListAsync());
        }

        // GET: Restaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRestaurantes = await _context.tblRestaurante
                .FirstOrDefaultAsync(m => m.IdRestaurante == id);
            if (tblRestaurantes == null)
            {
                return NotFound();
            }

            return View(tblRestaurantes);
        }

        // GET: Restaurantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRestaurante,NombreRestaurante,Decripcion,Logo,ImgDestacada")] tblRestaurantes tblRestaurantes,  IFormFile ImgDestacada, IFormFile Logo)
        {
            if (ModelState.IsValid)
            {

                //para los archivos de imagenes
                //para img destacada
                var recurso1 = string.Empty;
                var recurso2 = string.Empty;

                if (ImgDestacada != null && ImgDestacada.Length > 0)
                {
                  recurso1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\destacada",
                      String.Format("{0}{1}", DateTime.Now.Year, ImgDestacada.FileName));

                  using (var stream = new FileStream(recurso1, FileMode.Create))
                  {
                    await ImgDestacada.CopyToAsync(stream);
                  }

                  recurso1 = $"/destacada/{DateTime.Now.Year}{ImgDestacada.FileName}";
                }

                //par el Logo
                if (Logo != null && Logo.Length > 0)
                {
                  recurso2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\logo",
                      String.Format("{0}{1}", DateTime.Now.Year, Logo.FileName));

                  using (var stream = new FileStream(recurso2, FileMode.Create))
                  {
                    await Logo.CopyToAsync(stream);
                  }

                  recurso2 = $"/logo/{DateTime.Now.Year}{Logo.FileName}";
                }
                tblRestaurantes.Logo = recurso2;
                tblRestaurantes.ImgDestacada = recurso1;

                _context.Add(tblRestaurantes);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                   return View(tblRestaurantes);
        }

        // GET: Restaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRestaurantes = await _context.tblRestaurante.FindAsync(id);

            if (tblRestaurantes == null)
            {
                return NotFound();
            }
            
            return View(tblRestaurantes);
        }

        // POST: Restaurantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRestaurante,NombreRestaurante,Decripcion,Logo,ImgDestacada")] tblRestaurantes tblRestaurantes, IFormFile ImgDestacada, IFormFile Logo)
        {
            if (id != tblRestaurantes.IdRestaurante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {   
                try
                {
                    //para los archivos de imagenes
                    //para img ImgDestacada
                    var recurso1 = string.Empty;
                    var recurso2 = string.Empty;

                    if (ImgDestacada != null && ImgDestacada.Length > 0)
                    {
                      recurso1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\destacada",
                          String.Format("{0}{1}", DateTime.Now.Year, ImgDestacada.FileName));

                      using (var stream = new FileStream(recurso1, FileMode.Create))
                      {
                        await ImgDestacada.CopyToAsync(stream);
                      }

                      recurso1 = $"/destacada/{DateTime.Now.Year}{ImgDestacada.FileName}";
                    }

                    //par el Logo
                    if (Logo != null && Logo.Length > 0)
                    {
                      recurso2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Logo",
                          String.Format("{0}{1}", DateTime.Now.Year, Logo.FileName));

                      using (var stream = new FileStream(recurso2, FileMode.Create))
                      {
                        await Logo.CopyToAsync(stream);
                      }

                      recurso2 = $"/logo/{DateTime.Now.Year}{Logo.FileName}";
                    }
                    tblRestaurantes.Logo = recurso2;
                    tblRestaurantes.ImgDestacada = recurso1;


                     _context.Update(tblRestaurantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblRestaurantesExists(tblRestaurantes.IdRestaurante))
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
            return View(tblRestaurantes);
        }

        // GET: Restaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRestaurantes = await _context.tblRestaurante
                .FirstOrDefaultAsync(m => m.IdRestaurante == id);
            if (tblRestaurantes == null)
            {
                return NotFound();
            }

            return View(tblRestaurantes);
        }

        // POST: Restaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblRestaurantes = await _context.tblRestaurante.FindAsync(id);
            _context.tblRestaurante.Remove(tblRestaurantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblRestaurantesExists(int id)
        {
            return _context.tblRestaurante.Any(e => e.IdRestaurante == id);
        }
    }
}
