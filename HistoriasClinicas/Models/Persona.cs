using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Persona
    {
        public int Dni { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(30, ErrorMessage = "El campo {0} debe tener como máximo {1} caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Date)]
        public DateTime Nacimiento { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int Telefono { get; set; }

    }
}
