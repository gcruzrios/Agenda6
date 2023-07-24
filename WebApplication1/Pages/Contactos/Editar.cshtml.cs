using Agenda6.Modelos;
using Agenda6.Modelos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agenda6.Pages.Contactos
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public EditarModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
      
        [TempData]
        public string Mensaje { get; set; }

        public CrearContactoVM ContactoVM { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {


            ContactoVM = new CrearContactoVM()
            {
                ListaCategorias = await _contexto.Categoria.ToListAsync(),
                Contacto = await _contexto.Contacto.FindAsync(id)
            };
            return Page();

            //Contacto = await _contexto.Contacto.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ContactoDesdeBD = await _contexto.Contacto.FindAsync(ContactoVM.Contacto.Id);
                ContactoDesdeBD.Nombre = ContactoVM.Contacto.Nombre;
                ContactoDesdeBD.Email = ContactoVM.Contacto.Email;
                ContactoDesdeBD.Telefono = ContactoVM.Contacto.Telefono;
                ContactoDesdeBD.CategoriaId = ContactoVM.Contacto.CategoriaId;
                ContactoDesdeBD.FechaCreacion = ContactoVM.Contacto.FechaCreacion;
                await _contexto.SaveChangesAsync();
                Mensaje = "Curso editado correctamente";
                //return RedirectToPage("Index");
            }


            return RedirectToPage("Index");


        }
    }
}
