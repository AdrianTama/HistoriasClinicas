using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Episodio
    {
        public string Motivo { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Evolucion> Evoluciones { get; set; }

        public Boolean Estado { get; set; }

        public Epicrisis Epicrisis { get; set; }

    }
}
