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

        public int HistoricaClinicaId { get; set; }

        public HistoriaClinica HistoriaClinica { get; set; }

        public DateTime HoraCarga { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(10, ErrorMessage = "El campo {0} debe tener como mínimo {1} caracteres")]
        public string Diagnostico { get; set; }

        public ICollection<Recomendacion> Recomendaciones { get; set; }

        public ICollection<Nota> Notas { get; set; }


    }
}
