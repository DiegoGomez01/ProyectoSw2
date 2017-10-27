using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class Estudiante
    {
        public int Id { set; get; }
        [Required]
        public string CODIGO { set; get; }
        [Required]
        public string CARRERA { set; get; }
        [Required]
        public string PENSUM { set; get; }
        [Required]
        public string NOMBRE { set; get; }
        [Required]
        public string P_APELLIDO { set; get; }
        [Required]
        public string S_APELLIDO { set; get; }
        [Required]
        public string TELEFONO { set; get; }
        [Required]
        public string SEMESTRE_INGRES { set; get; }
        [Required]
        public string SEM_ACADEMICO { set; get; }
        [Required]
        public string SEXO { set; get; }
        [Required]
        public string ESTADO { set; get; }
        [Required]
        public string DOCUMENTO { set; get; }
        [Required]
        public string TIPO_DOCUMENTO { set; get; }
        [EmailAddress]
        [Required]
        public string EMAIL { set; get; }

        public virtual ICollection<EstudianteXGrupo> colEstudianteGrupo { get; set; }
        public virtual ICollection<EstudianteXMateria> colEstudianteMateria { get; set; }
        public virtual ICollection <SolicitudEstudianteMateria> colSolicitudEstudianteMateria { set; get; }
    }
}