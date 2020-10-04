using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Paciente : Persona
    {
        [Key]
        public int Dni { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }

        public string ObraSocial { get; set; }
       
    }
}
