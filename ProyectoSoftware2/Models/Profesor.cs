using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models{
    public class Profesor{
        public int Id { set; get; }
        [Required]
        public String Nombre { set; get; }
        [Required]
        public int Telefono { set; get; }
        [EmailAddress]
        [Required]
        public String Correo { set; get; }
        public virtual ICollection<AreaXProfesor> ColAreaProfesor { get; set; }
    }
}