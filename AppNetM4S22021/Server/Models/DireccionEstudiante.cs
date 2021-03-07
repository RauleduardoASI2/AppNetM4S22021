using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppNetM4S22021.Server.Models
{
    public class DireccionEstudiante
    {
        [Key]
        public int IdDireccionEstudiante { get; set; }
        public string  Direccion1 { get; set; }
        public string Direccion2 { get; set; }

        public virtual Estudiantes Estudiantes { get; set; }

    }
}
