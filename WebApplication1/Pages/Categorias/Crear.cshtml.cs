using Agenda6.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda6.Pages.Categorias
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Categoria Categoria { get; set; }

        [TempData]
        public string Mensaje { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }
            Categoria.FechaCreacion = DateTime.Now;
            _contexto.Add(Categoria);
            await _contexto.SaveChangesAsync();
            Mensaje = "Categoria creada correctamente";
            return RedirectToPage("Index");


        }
    }
}
