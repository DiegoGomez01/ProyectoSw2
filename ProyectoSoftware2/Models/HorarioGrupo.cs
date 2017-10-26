using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class HorarioGrupo
    {
        public int Id { set; get; }
        [Required]
        public string CODIGOMATERIA { set; get; }
        [Required]
        public string ANO { set; get; }
        [Required]
        public string PERIODO { set; get; }
        [Required]
        public string GRUPO { set; get; }
        [Required]
        public string DIA { set; get; }
        [Required]
        public int HORA { set; get; }
        [Required]
        public int DURACION { set; get; }
        [Required]
        public string AULA { set; get; }

        public virtual Grupo Group { get; set; }
    }
}