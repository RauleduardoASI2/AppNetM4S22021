using System;
using System.Data.Entity.ModelConfiguration.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppNetM4S22021.Server.Models
{
    public partial class RegistroAcademicoContext : DbContext
    {
        public RegistroAcademicoContext()
        {
        }

        public RegistroAcademicoContext(DbContextOptions<RegistroAcademicoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Seccion> Seccion { get; set; }
        public virtual DbSet<Facultad> Facultad { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<DireccionEstudiante> DireccionEstudiantes { get; set; }
        public virtual DbSet<Maestros> Maestros { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-8AN1V34\\SQLEXPRESS;database=RegistroAcademico;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
