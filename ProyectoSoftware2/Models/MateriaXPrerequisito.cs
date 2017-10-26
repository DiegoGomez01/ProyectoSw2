using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models{
    public class MateriaXPrerequisito{ 
        public int Id { get; set;}
        [Required]
        public int MateriaId { get; set; }
        [Required]
        public int PreRequisitoId { get; set; }

        public virtual Materia Materia { get; set; }
        public virtual PreRequisito PreRequisito { get; set; }
    }
}