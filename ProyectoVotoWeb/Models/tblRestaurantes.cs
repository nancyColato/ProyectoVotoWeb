using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVotoWeb.Models
{
  public class tblRestaurantes
  {
    [Key]
    public int IdRestaurante { get; set; }

    [Required]
    [Display(Name = "Nombre")]
    public string NombreRestaurante { get; set; }

    [DataType(DataType.MultilineText)]
    public string Decripcion { get; set; }

    [DataType(DataType.Upload)]
    public string Logo { get; set; }

    [Display(Name = "Imagen Destacada")]
    [DataType(DataType.Upload)]
    public string ImgDestacada { get; set; }



    //Relacion de Listado
    public ICollection<tblHorarios> tblHorario { get; set; }
    public ICollection<tblVotaciones> tblVotacion { get; set; }
  }
}
