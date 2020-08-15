using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Evolucion
    {
        public int EvolucionId { get; set; }
       
        public int Matricula { get; set; }

        public Medico Medico { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaYHoraInicio { get; set; } = DateTime.Now;
        public DateTime FechaYHoraAlta { get; set; }
        public DateTime FechaYHoraCierre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(10, ErrorMessage = "El campo {0} debe tener como mínimo {1} caracteres")]
        public string DescripcionAtencion { get; set; }

        public Boolean EstadoAbierto { get; set; }

        public ICollection<Nota> Notas { get; set; }

    }
}
