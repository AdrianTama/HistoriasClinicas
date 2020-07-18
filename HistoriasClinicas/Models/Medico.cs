﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Medico
    {
        [Key]
        public string CodEmpleado { get; set; }

        public string Especialidad { get; set; }

    }
}
