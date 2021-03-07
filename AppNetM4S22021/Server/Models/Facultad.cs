using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppNetM4S22021.Server.Models
{
    public class Facultad
    {
        [Key]
        public int FacultadId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Estudiantes> EstudiantesFacultad { get; set; }
    }
}
