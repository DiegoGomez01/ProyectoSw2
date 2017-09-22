using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class Plantilla
    {
        public int Id { get; set; }
        public String nombre { get; set; }
        public string descripcion { get; set; }
        public string ruta { get; set;  }
    }
}