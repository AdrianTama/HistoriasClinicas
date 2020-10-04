using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Nota
    {
        public int NotaId { get; set; }

        public int EvolucionId { get; set; }
        public Evolucion Evolucion { get; set; }

        public string Legajo { get; set; }
        public Empleado Empleado { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(10, ErrorMessage = "El campo {0} debe tener como mínimo {1} caracteres")]
        public string Mensaje { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaYHora { get; set; }
    }
}
