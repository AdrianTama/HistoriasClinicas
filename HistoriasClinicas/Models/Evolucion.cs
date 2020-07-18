using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Evolucion
    {
        public int EvolucionId { get; set; }
        public Medico Medico { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }

        public string Descripcion { get; set; }

        public Boolean Estado { get; set; }

    }
}
