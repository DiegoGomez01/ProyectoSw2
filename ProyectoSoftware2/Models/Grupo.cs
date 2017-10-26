using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class Grupo
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
        public int CUPO { set; get; }
        [Required]
        public DateTime FECHA_INICIO { set; get; }
        [Required]
        public DateTime FECHA_FINAL { set; get; }
        [Required]
        public int CUPO_LINEA { set; get; }
        [Required]
        public DateTime INICIO_INSCRIPCION { set; get; }
        [Required]
        public DateTime FIN_INSCRIPCION { set; get; }
        [Required]
        public DateTime FIN_CANCELACION { set; get; }
        [Required]
        public DateTime FECHA_CREACION { set; get; }

        public virtual ICollection<HorarioGrupo> colHorarioGrupo { get; set; }
        public virtual ICollection<ProfesorXGrupo> colProfesorGrupo { get; set; }
        public virtual ICollection<EstudianteXGrupo> colEstudianteGrupo { get; set; }
    }
}