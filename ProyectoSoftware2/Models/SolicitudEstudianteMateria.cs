using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class SolicitudEstudianteMateria
    {
        public int Id { set; get; }
        [required]
        public int EstudianteId { set; get; }
        [required]
        public int MateriaId { set; get; }

        public virtual Materia Materia { set; get; }
        public virtual Estudiante Estudiante { set; get; }
    }
}