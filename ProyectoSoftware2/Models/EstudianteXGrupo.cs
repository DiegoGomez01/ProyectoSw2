using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class EstudianteXGrupo
    {
        public int Id { get; set; }
        [required]
        public int EstudianteId { get; set; }
        [required]
        public int GrupoId { set; get; }

        public virtual Estudiante Estudiante { set; get; }
        public virtual Grupo Group { set; get; }
    }
}