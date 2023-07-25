using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda6.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Scripting;

namespace Agenda6.Pages.Usuarios
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;
        public LoginModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }
        [BindProperty]
        public Usuario Usuario { get; set; }
        public string PasswordVerificado { get; set; }
        public bool Verificado { get; set; }
        [TempData]
        public string Mensaje { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()

        {
                       

            if (ModelState.IsValid)




            {

                

                //  PasswordVerificado = BCrypt.Net.BCrypt.HashPassword(Usuario.Password);


                //var UsuarioDesdeBD = await _contexto.Usuario.FindAsync(Usuario.NombreUsuario);
                
               
                var UsuarioDesdeBD = _contexto.Usuario.FirstOrDefault(acc => acc.NombreUsuario == Usuario.NombreUsuario);


                UsuarioDesdeBD.NombreUsuario = Usuario.NombreUsuario;
                UsuarioDesdeBD.Password = Usuario.Password;

                bool Verificado = BCrypt.Net.BCrypt.Verify(Usuario.Password, UsuarioDesdeBD.Password);


                if (Verificado)
                {

                }                  
                
                else
                {
                    Mensaje = "Las Credenciales de usuario fallaron";
                    return RedirectToPage("Index");
                }
            }




            //bool verified = BCrypt.Net.BCrypt.Verify(Usuario.Password, Usuario.Password);




            Mensaje = "Usuario ingresado correctamente";
            return RedirectToPage("Home");


        }


    }
}
