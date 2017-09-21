using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models{
    public class AreaXProfesor{
        public int Id { get; set; }
        [Required]
        public int ProfesorId { get; set; }
        [Required]
        public int AreaId { get; set; }

        public virtual Area Area { get; set; }
        public virtual Profesor Profesor { get; set; }
    }

}