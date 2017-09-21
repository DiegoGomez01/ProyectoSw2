using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models{
    public class AreaXProfesor{
        public int Id { get; set; }
        public int ProfesorId { get; set; }
        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
        public virtual Profesor Profesor { get; set; }
    }

}