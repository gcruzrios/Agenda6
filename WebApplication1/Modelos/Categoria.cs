using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda6.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de Categoria es obligatorio")]
        [StringLength (30, ErrorMessage = "{0} el nombre debe tener entre {2} y {1}", MinimumLength =4)]
        [Display(Name = "Nombre Categoria")]
        public string? Nombre { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Fecha de Creacion")]
        public DateTime? FechaCreacion { get; set; }

    }
}
