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
        public Usuario Usuario { get; set; }
        public string PasswordVerificado { get; set; }
        public string Mensaje { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            PasswordVerificado = BCrypt.Net.BCrypt.HashPassword(Usuario.Password);

            if (ModelState.IsValid)
            {
                var UsuarioDesdeBD = await _contexto.Usuario.FindAsync(Usuario.NombreUsuario);
                UsuarioDesdeBD.NombreUsuario = Usuario.NombreUsuario;
                UsuarioDesdeBD.Password = Usuario.Password;

                if (UsuarioDesdeBD.Password == PasswordVerificado)
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
