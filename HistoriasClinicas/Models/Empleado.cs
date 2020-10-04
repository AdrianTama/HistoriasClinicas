using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Empleado : Persona
    {
        [Key]
        public string Legajo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int Dni { get; set; }
    }
}
