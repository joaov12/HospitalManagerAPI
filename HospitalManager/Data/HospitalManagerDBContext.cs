using HospitalManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.Data
{
    public class HospitalManagerDBContext : DbContext
    {
        public HospitalManagerDBContext(DbContextOptions<HospitalManagerDBContext> options)
            : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Enfermeiro> Enfermeiros { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

    }
}
