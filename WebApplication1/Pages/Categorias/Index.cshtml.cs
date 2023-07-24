using Agenda6.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda6.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        public IEnumerable<Categoria> Categorias { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Categorias = await _contexto.Categoria.ToListAsync();
           
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {

            var categoria = await _contexto.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _contexto.Categoria.Remove(categoria);
            await _contexto.SaveChangesAsync();
            //return RedirectToPage("Index");
            Mensaje = "Categoria borrada correctamente";

            return RedirectToPage("Index");


        }
    }
}
