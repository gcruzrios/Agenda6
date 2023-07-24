using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda6.Modelos
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(35, ErrorMessage = "{0} el nombre debe tener entre {2} y {1}", MinimumLength = 4)]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }


        [Required(ErrorMessage = "El Email es obligatorio")]
        [StringLength(35, ErrorMessage = "{0} el nombre debe tener entre {2} y {1}", MinimumLength = 4)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El Teléfono es obligatorio")]
        [StringLength(15, ErrorMessage = "{0} el nombre debe tener entre {2} y {1}", MinimumLength = 4)]
        [Display(Name = "Telefono")]
        public string? Telefono { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Creacion")]
        public DateTime? FechaCreacion { get; set; }

        [Required]
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }


    }
}
