using Agenda6.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agenda6.Pages.Cursos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Curso Curso { get; set; }
        [TempData]
        public string Mensaje { get; set; }
        public async Task OnGet(int id)
        {
            Curso = await _contexto.Curso.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var CursoDesdeBD = await _contexto.Curso.FindAsync(Curso.Id);
                CursoDesdeBD.NombreCurso = Curso.NombreCurso;
                CursoDesdeBD.CantidadClases = Curso.CantidadClases;
                CursoDesdeBD.Precio = Curso.Precio;

                await _contexto.SaveChangesAsync();
                Mensaje = "Curso editado correctamente";
                //return RedirectToPage("Index");
            }


            return RedirectToPage("Index");


        }
    }
}
