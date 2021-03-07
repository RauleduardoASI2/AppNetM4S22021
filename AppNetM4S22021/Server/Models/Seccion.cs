using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppNetM4S22021.Server.Models
{
    public partial class Seccion
    {
        [Key]
        public int IdSeccion { get; set; }
        public string Nombre { get; set; }
    }
}
