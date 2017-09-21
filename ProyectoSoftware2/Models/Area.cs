using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models{
    public class Area{
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }

        public virtual ICollection<AreaXProfesor> ColAreaProfesor { get; set; }
    }
}