﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoriasClinicas.Models
{
    public class Administrativo : Persona
    {
        [Key]
        public string CodEmpleado { get; set; }

    }
}