using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppNetM4S22021.Server.Models
{
    public class Estudiantes
    {
        public Estudiantes()
        {
            this.Cursos = new HashSet<Cursos>();
        }
        [Key, Column(Order = 0)]
        public int IdEstudiante { get; set; }
        [Column("Nombre", Order =1), MaxLength(50), Required, ConcurrencyCheck]
        public string Estudiantenombre { get; set; }
        [Column("DoB", TypeName="DateTime2", Order = 5)]
        public DateTime? FechaNacimiento { get; set; }
        public byte[] Photo { get; set; }
        [NotMapped]
        public decimal Altura { get; set; }
        public float Peso { get; set; }
        public int Edad { get; set; }
        public int FacultadRefId { get; set; }
        [ForeignKey("FacultadRefId")]
        public virtual Facultad Facultad{ get; set; }
        [Index]
        public int NumeroRegistro { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        [NotMapped]
        public virtual DireccionEstudiante Direcciones { get; set; }
        public int GradoId { get; set; }
        
        public virtual Grado Grado { get; set; }
        [NotMapped]
        public ICollection<Cursos> Cursos { get; set; }

    }
}
