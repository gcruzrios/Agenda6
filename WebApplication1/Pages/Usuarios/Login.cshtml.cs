using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Agenda6.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;

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

                if (UsuarioDesdeBD == null)
                {
                    Mensaje = "Las Credenciales de usuario fallaron";
                    return RedirectToPage("/Index");
                }
                else
                {
                   storedPassword = UsuarioDesdeBD.Password;
                }

                //var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

                int salt = 12;
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(Usuario.Password, salt);
                
                //bool correctPassword = BCrypt.Net.BCrypt.Verify(storedPassword, passwordHash);

                if (!BCrypt.Net.BCrypt.Verify(Usuario.Password, storedPassword))
                {
                    
                    Mensaje = "Las Credenciales de usuario fallaron";
                    return RedirectToPage("/Index");
                }
                else
                {
                    Mensaje = "Usuario ingresado correctamente";
                    

                }
                // authentication successful

                
               
                
                //int salt = 12;
                //string passwordHash = BCrypt.Net.BCrypt.HashPassword(enteredpassword, salt);
                //bool correctPassword = BCrypt.Net.BCrypt.Verify(storedPassword, passwordHash);

                //int salt = 12;
                //string passwordHash = BCrypt.Net.BCrypt.HashPassword(Usuario.Password, salt);
                //bool correctPassword = BCrypt.Net.BCrypt.Verify(storedPassword, passwordHash);

                //bool Verificado = BCrypt.Net.BCrypt.Verify(Usuario.Password, UsuarioDesdeBD.Password);


                //if (correctPassword)
                                  
                
                
            }




            //bool verified = BCrypt.Net.BCrypt.Verify(Usuario.Password, Usuario.Password);




            Mensaje = "Usuario ingresado correctamente";
            return RedirectToPage("/Home");


        }


    }
}
