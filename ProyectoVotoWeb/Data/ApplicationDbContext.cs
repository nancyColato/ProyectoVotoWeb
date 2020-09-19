using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoVotoWeb.Models;

namespace ProyectoVotoWeb.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<tblHorarios> tblHorario { get; set; }
    public DbSet<tblRestaurantes> tblRestaurante { get; set; }
    public DbSet<tblVotaciones> tblVotacion { get; set; }
  }
}
