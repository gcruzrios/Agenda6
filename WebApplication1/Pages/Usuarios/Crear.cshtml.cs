using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda6.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Scripting;

namespace Agenda6.Pages.Usuarios
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Usuario Usuario { get; set; }

        [TempData]
        public string Mensaje { get; set; }
        public List<SelectListItem> Roles { get; set; }
        public void OnGet()

        {
            
            Roles = new List<SelectListItem>
            {
                new SelectListItem{ Value = "Admin", Text = "Admin"},
                new SelectListItem{ Value = "Ventas", Text = "Ventas"},
                new SelectListItem{ Value = "IT", Text = "IT"},
             };
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int salt = 12;
            Usuario.Password = BCrypt.Net.BCrypt.HashPassword(Usuario.Password,salt);

            Usuario.FechaCreacion = DateTime.Now;
            _contexto.Add(Usuario);
            await _contexto.SaveChangesAsync();
            Mensaje = "Usuario creado correctamente";
            return RedirectToPage("Index");


        }

    }
}
