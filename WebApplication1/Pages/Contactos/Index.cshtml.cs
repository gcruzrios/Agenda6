using Agenda6.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda6.Pages.Contactos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        public IEnumerable<Contacto> Contactos { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Contactos = await _contexto.Contacto.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {

            var contacto = await _contexto.Contacto.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            _contexto.Contacto.Remove(contacto);
            await _contexto.SaveChangesAsync();
            //return RedirectToPage("Index");
            Mensaje = "Contacto borrado correctamente";

            return RedirectToPage("Index");


        }
    }
}
