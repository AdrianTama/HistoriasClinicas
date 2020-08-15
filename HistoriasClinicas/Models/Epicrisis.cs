using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Epicrisis
    {
        public int EpicrisisId { get; set; }

        public int EpisodioId { get; set; }
        public Episodio Episodio { get; set; }

        public int Matricula { get; set; }
        public Medico Medico { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaYHora { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(10, ErrorMessage = "El campo {0} debe tener como mínimo {1} caracteres")]

        public int DiagnosticoId { get; set; }
        public Diagnostico Diagnostico { get; set; }


    }
}
