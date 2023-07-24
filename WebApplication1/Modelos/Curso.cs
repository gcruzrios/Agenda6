using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda6.Modelos
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nombre de curso")]

        public string? NombreCurso { get; set; }
        [Display(Name = "Cantidad de clases")]
        public int CantidadClases { get; set; }

        public int Precio { get; set; }
        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }

    }
}
