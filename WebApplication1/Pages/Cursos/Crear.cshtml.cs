using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda6.Modelos;

namespace Agenda6.Pages.Cursos
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Curso Curso { get; set; }

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
            Curso.FechaCreacion = DateTime.Now;
            _contexto.Add(Curso);
            await _contexto.SaveChangesAsync();
            Mensaje = "Curso creado correctamente";
            return RedirectToPage("Index");


        }

    }
}
