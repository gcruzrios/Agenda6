using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda6.Modelos;
using Microsoft.EntityFrameworkCore;



namespace Agenda6.Pages.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        public IEnumerable<Usuario> Usuarios { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Usuarios = await _contexto.Usuario.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {

            var usuario = await _contexto.Usuario.FindAsync(id);
            if (usuario== null)
            {
                return NotFound();
            }

            _contexto.Usuario.Remove(usuario);
            await _contexto.SaveChangesAsync();
  
            Mensaje = "Usuario borrado correctamente";

            return RedirectToPage("Index");


        }
    }
}
