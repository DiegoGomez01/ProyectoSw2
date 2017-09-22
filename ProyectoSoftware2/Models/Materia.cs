﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class Materia
    {
        public int Id { get; set; }
        [required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<SolicitarCupo> colSolicitarCupo { get; set; }
    }
}