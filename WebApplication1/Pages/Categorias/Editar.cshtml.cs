using Agenda6.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda6.Pages.Categorias
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Categoria Categoria { get; set; }
        [TempData]
        public string Mensaje { get; set; }
        public async Task OnGet(int id)
        {
            Categoria = await _contexto.Categoria.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CategoriaDesdeBD = await _contexto.Categoria.FindAsync(Categoria.Id);
                CategoriaDesdeBD.Nombre = Categoria.Nombre;
                

                await _contexto.SaveChangesAsync();
                Mensaje = "Categoria editada correctamente";
                //return RedirectToPage("Index");
            }


            return RedirectToPage("Index");


        }
    }
}
