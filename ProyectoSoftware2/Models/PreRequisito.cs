using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class PreRequisito
    {
        public int Id { set; get; }
        [Required]
        public string PENSUM { set; get; }
        [Required]
        public string CODIGOMATERIA { set; get; }
        [Required]
        public string CODIGOMATERIA_PRE { set; get; }

        public virtual ICollection<MateriaXPrerequisito> ColPreRequisitoMateria { get; set; }
    }
}