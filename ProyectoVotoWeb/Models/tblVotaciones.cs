using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVotoWeb.Models
{
  public class tblVotaciones
  {
    [Key]
    public int IdVoto { get; set; }

    [Display(Name = "Votos")]
    public int NumVotos { get; set; }

    //Llaves
    public int IdRestaurante { get; set; }
    public virtual tblRestaurantes tblRestaurante { get; set; }
  }
}
