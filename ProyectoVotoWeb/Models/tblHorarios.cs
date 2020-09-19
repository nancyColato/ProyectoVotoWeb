using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoVotoWeb.Models
{
  public class tblHorarios
  {
    [Key]
    public int IdHorario { get; set; }

    [Required]
    [Display(Name = "Apertura")]
    public TimeSpan HoraApertura { get; set; }

    [Required]
    [Display(Name = "Cierre")]
    public TimeSpan HoraCierre { get; set; }

    [Required]
    [Display(Name = "Dia de Inicio")]
    public string DiaInicio { get; set; }

    [Required]
    [Display(Name = "Dia de fin")]
    public string DiaFin { get; set; }

    public string Horario { get => (HoraApertura + " - " + HoraCierre); }

    public string Dias { get=>(DiaInicio + " - " + DiaFin); }

    ///Relacion con restaurante
    [Display(Name = "Restaurante")]
    public int IdRestaurante { get; set; } //Campo clave foranea
    //Entity Framewrok Core
    public virtual tblRestaurantes tblRestaurante { get; set; } //Objeto de naveg
  }
}
