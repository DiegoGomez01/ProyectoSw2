﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models{
    public class Bloque{
        public int Id { get; set; }
        [Required]
        public String Nombre { get; set; }
        public String Descripcion { get; set; }

        public virtual ICollection<Sala> colSala { get; set; }
    }
}