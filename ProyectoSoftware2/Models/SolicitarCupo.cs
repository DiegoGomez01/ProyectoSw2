using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoSoftware2.Models
{
    public class SolicitarCupo
    {
        public int Id { get; set; }
        public int MateriaId { get; set; }
        public int CodEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public Materia materia { get; set; }
        
    }
}