using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class ProfesorXGrupo
    {
        public int Id { get; set; }
        [required]
        public int ProfesorId { get; set; }
        [required]
        public int GrupoId { get; set; }
        [required]
        public int HorasDictadas { set; get; }

        public virtual Profesor Profesor { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}