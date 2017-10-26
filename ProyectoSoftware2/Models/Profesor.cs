using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models{
    public class Profesor{
        public int Id { set; get; }
        [Required]
        public string P_APELLIDO { set; get; }
        [Required]
        public string S_APELLIDO { set; get; }
        [Required]
        public string NOMBRES { set; get; }
        public string DIRECCION { set; get; }
        [Required]
        public string TELEFONO { set; get; }
        [Required]
        public string SEXO { set; get; }
        [Required]
        public DateTime FECHA_INICIO { set; get; }
        [Required]
        public DateTime FECHA_FIN { set; get; }
        [Required]
        public string DEPARTAMENTO { set; get; }
        [EmailAddress]
        [Required]
        public string EMAIL { set; get; }
        public virtual ICollection<AreaXProfesor> colAreaProfesor { get; set; }
        public virtual ICollection<ProfesorXGrupo> colProfesorGrupo { get; set; }
        public virtual ICollection<HorarioDesfavorableProfesor> colHorarioDesfavorable { get; set; }
    }
}