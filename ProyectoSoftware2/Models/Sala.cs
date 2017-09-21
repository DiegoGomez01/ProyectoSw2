using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models{
    public class Sala{
        public int Id { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        public int BloqueId { get; set; }
        public Boolean VideoBeam { get; set; }
        public Boolean Televisor { get; set; }
        public String Descripcion { get; set; }

        public virtual Bloque Bloque { get; set; }
    }
}