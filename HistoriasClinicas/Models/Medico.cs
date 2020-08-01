using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Medico : Persona
    {
        [Key]
        public string CodEmpleado { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(5, ErrorMessage = "El campo {0} debe tener como mínimo {1} caracteres")]
        public string Especialidad { get; set; }

    }
}
