using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class HorarioDesfavorableProfesor
    {
        public int Id { set; get; }
        [Required]
        public string CEDULADOCENTE { set; get; }
        [Required]
        public string DIA { set; get; }
        [Required]
        public int HORA { set; get; }
        [Required]
        public int DURACION { set; get; }

        public virtual Profesor Profesor { get; set; }
    }
}