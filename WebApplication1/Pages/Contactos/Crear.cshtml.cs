
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agenda6.Modelos.ViewModels;
using Agenda6.Modelos;
namespace Agenda6.Pages.Contactos
{
    public class CrearModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

       
        public CrearModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]

        public CrearContactoVM ContactoVM { get; set; }
        [TempData]
        public string Mensaje { get; set; }
      
        
        public async Task<IActionResult> OnGet()
        {
            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                Contacto = new Modelos.Contacto()

            };
           return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }
            ContactoVM.Contacto.FechaCreacion = DateTime.Now;
            //_contexto.Add(ContactoVM.Contacto);
            await _contexto.Contacto.AddAsync(ContactoVM.Contacto);
            await _contexto.SaveChangesAsync();
            Mensaje = "Contacto creado correctamente";
            return RedirectToPage("Index");


        }
    }
}
