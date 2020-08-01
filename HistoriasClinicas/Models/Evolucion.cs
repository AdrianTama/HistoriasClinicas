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
       
        public string CodEmpleado { get; set; }

        public Medico Medico { get; set; }

        public DateTime HoraInicio { get; set; } = DateTime.Now;

        public DateTime HoraFin { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(10, ErrorMessage = "El campo {0} debe tener como mínimo {1} caracteres")]
        public string Descripcion { get; set; }

        public Boolean EstadoAbierto { get; set; }

    }
}
