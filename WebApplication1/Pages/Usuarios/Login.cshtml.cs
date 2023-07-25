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
        public string storedPassword { get; set; }

        [TempData]
        public string Mensaje { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()

        {
                       

            if (ModelState.IsValid)




            {



                //bool verified = BCrypt.Net.BCrypt.Verify("Pa$$w0rd", passwordHash);


                //var UsuarioDesdeBD = await _contexto.Usuario.FindAsync(Usuario.NombreUsuario);


                var UsuarioDesdeBD = _contexto.Usuario.FirstOrDefault(acc => acc.NombreUsuario == Usuario.NombreUsuario);

                storedPassword = UsuarioDesdeBD.Password;
               
                
                //int salt = 12;
                //string passwordHash = BCrypt.Net.BCrypt.HashPassword(enteredpassword, salt);
                //bool correctPassword = BCrypt.Net.BCrypt.Verify(storedPassword, passwordHash);

                int salt = 12;
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(Usuario.Password, salt);
                bool correctPassword = BCrypt.Net.BCrypt.Verify(storedPassword, passwordHash);

                //bool Verificado = BCrypt.Net.BCrypt.Verify(Usuario.Password, UsuarioDesdeBD.Password);


                if (correctPassword)
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
            return RedirectToPage("/Home");


        }


    }
}
