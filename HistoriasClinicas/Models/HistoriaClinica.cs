using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class HistoriaClinica
    {
        public int HistoriaClinicaId { get; set; }

        public int PacienteId { get; set; }

        public Paciente Paciente { get; set; }

        public ICollection<Episodio> Episodios { get; set; }


    }
}
