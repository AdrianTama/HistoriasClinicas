using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Epicrisis
    {
        public HistoriaClinica HistoriaClinica { get; set; }

        public DateTime HoraCarga { get; set; }

        public string Diagnostico { get; set; }

        public ICollection<Recomendacion> Recomendaciones { get; set; }

        public ICollection<Nota> Notas { get; set; }

    }
}
