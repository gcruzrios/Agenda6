using Agenda6.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda6.Pages.Usuarios
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Usuario Usuario { get; set; }
        [TempData]
        public string Mensaje { get; set; }
        public async Task OnGet(int id)
        {
            Usuario = await _contexto.Usuario.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var UsuarioDesdeBD = await _contexto.Usuario.FindAsync(Usuario.Id);
                UsuarioDesdeBD.NombreUsuario = Usuario.NombreUsuario;
         
                UsuarioDesdeBD.Role = Usuario.Role;

                await _contexto.SaveChangesAsync();
                Mensaje = "Usuario editado correctamente";
                //return RedirectToPage("Index");
            }


            return RedirectToPage("Index");


        }
    }
}
