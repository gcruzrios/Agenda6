using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda6.Modelos;
using Microsoft.EntityFrameworkCore;



namespace Agenda6.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        public IEnumerable<Curso> Cursos { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Cursos = await _contexto.Curso.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {

            var curso = await _contexto.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _contexto.Curso.Remove(curso);
            await _contexto.SaveChangesAsync();
            //return RedirectToPage("Index");
            Mensaje = "Curso borrado correctamente";

            return RedirectToPage("Index");


        }
    }
}
