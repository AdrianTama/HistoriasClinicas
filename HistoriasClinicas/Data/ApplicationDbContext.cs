using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HistoriasClinicas.Models;

namespace HistoriasClinicas.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Administrativo> Administrativos { get; set; }
        public DbSet<Recomendacion> Recomendaciones { get; set; }
        public DbSet<Evolucion> Evoluciones { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }
        public DbSet<Epicrisis> Epicrisis { get; set; }
        public DbSet<Episodio> Episodios { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
    }
}
