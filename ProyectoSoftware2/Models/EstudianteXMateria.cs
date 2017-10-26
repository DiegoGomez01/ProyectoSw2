using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class EstudianteXMateria
    {
        public int Id { set; get; }
        [Required]
        public string ESTUDIANTEID { set; get; }
        [Required]
        public string MATERIAID { set; get; }
        [Required]
        public string GRUPO { set; get; }
        [Required]
        public double DEFINITIVA { set; get; }
        public string HABILITACION { set; get; }
        public string RECUPERATORIO { set; get; }
        public double FINAL { set; get; }
        [Required]
        public int FALLAS { set; get; }
        [Required]
        public string PERIODO { set; get; }
        [Required]
        public string ANO { set; get; }

        public virtual Materia Materia { set; get; }
        public virtual Estudiante Estudiante { set; get; }
    }
}