using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }


    }
}
