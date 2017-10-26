using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class Materia
    {
        public int Id { set; get; }
        [Required]
        public string NOMBRE { set; get; }
        [Required]
        public int HORAS_TEO { set; get; }
        [Required]
        public int HORAS_PRAC { set; get; }
        [Required]
        public int H_NOPRESEN { set; get; }
        [Required]
        public string DEPARTAMENTO { set; get; }
        [Required]
        public int CREDITOS { set; get; }
        [Required]
        public string MODALIDAD { set; get; }
        [Required]
        public int CUPO { set; get; }
        [Required]
        public string ABIERTA { set; get; }

        public virtual ICollection<MateriaXPrerequisito> ColPreRequisitoMateria { get; set; }
        public virtual ICollection<EstudianteXMateria> colEstudianteMateria { get; set; }
    }
}