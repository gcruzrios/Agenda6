using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda6.Modelos
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nombre de usuario")]

        public string? NombreUsuario { get; set; }
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Rol de Usuario")]
        public string Role { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime FechaCreacion { get; set; }

    }
}
