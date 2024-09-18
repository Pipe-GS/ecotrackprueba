using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoTrack.Models
{
    public class Actividad
    {
        [Key]
        public int IdActividad { get; set; }

        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }

        [Required]
        public int IdTipoActividad { get; set; }
        [ForeignKey("IdTipoActividad")]
        public required TipoActividad TipoActividad { get; set; }

        [Required]
        public required string Ubicacion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TimeSpan Duracion { get; set; }

        public required DatosClima Clima { get; set; }
    }
}
