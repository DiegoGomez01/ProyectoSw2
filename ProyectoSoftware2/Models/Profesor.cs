using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models{
    public class Profesor{
        public int Id { set; get; }
        public String Nombre { set; get; }
        public int Telefono { set; get; }
        [EmailAddress]
        public String Correo { set; get; }
        public virtual ICollection<AreaXProfesor> ColAreaProfesor { get; set; }
    }
}