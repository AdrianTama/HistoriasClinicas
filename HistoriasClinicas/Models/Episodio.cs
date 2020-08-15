using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Episodio
    {
        public int EpisodioId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(10, ErrorMessage = "El campo {0} debe tener como mínimo {1} caracteres")]
        public string Motivo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(10, ErrorMessage = "El campo {0} debe tener como mínimo {1} caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaYHoraInicio { get; set; }
        public DateTime FechaYHoraAlta { get; set; }
        public DateTime FechaYHoraCierre { get; set; }

        public ICollection<Evolucion> Evoluciones { get; set; }


        public Boolean EstadoAbierto { get; set; }

        public int EpicrisisId { get; set; }
        public Epicrisis Epicrisis { get; set; }
        public string Legajo { get; set; }
        public Empleado EmpleadoRegistra { get; set; }

    }
}
