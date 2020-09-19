using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProyectoVotoWeb.Data;
using ProyectoVotoWeb.Models;

namespace ProyectoVotoWeb.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    private readonly ApplicationDbContext _context;


    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
      _logger = logger;
      _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
      ViewBag.Restaurantes = await _context.tblRestaurante.Include(x => x.tblVotacion).ToListAsync();
      ViewBag.Horarios = await _context.tblHorario.ToListAsync();
      ViewBag.Votos = await _context.tblVotacion.ToListAsync();
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(int IdRestaurante)
    {
      tblVotaciones votos = new tblVotaciones();
      votos.NumVotos++;
      votos.IdRestaurante = IdRestaurante;
      _context.Add(votos);
      await _context.SaveChangesAsync();
      ViewBag.Votos = await _context.tblVotacion.ToListAsync();
      ViewBag.Horarios = await _context.tblHorario.ToListAsync();
      ViewBag.Restaurantes = await _context.tblRestaurante.Include(x => x.tblVotacion).ToListAsync();
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
