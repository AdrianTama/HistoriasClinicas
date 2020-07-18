using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class HistoriaClinica
    {
        public Paciente Paciente { get; set; }

        public ICollection<Episodio> Episodios { get; set; }

    }
}
