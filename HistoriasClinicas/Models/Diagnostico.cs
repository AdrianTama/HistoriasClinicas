using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Diagnostico
    {
        public int DiagnosticoId { get; set; }

        public int EpicrisisId { get; set; }
        public Epicrisis Epicrisis { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Recomendacion { get; set; }
    }
}
