using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppNetM4S22021.Server.Models
{
    public class Cursos
    {
        [Key]
        public int CursoId { get; set; }
        public string NombreCurso { get; set; }
        public string descripcion { get; set; }

        [ForeignKey("onLineMaestros")]
        public int? onLineMaestrosId { get; set; }
        public Maestros onLineMaestros { get; set; }

        [ForeignKey("presencialMaestros")]
        public int? presencialMaestrosId { get; set; }
        public Maestros presencialMaestros { get; set; }

        public ICollection<Estudiantes> Estudiantes { get; set; }


    }
}
