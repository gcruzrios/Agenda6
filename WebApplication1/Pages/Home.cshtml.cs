using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        [TempData]
        public string Mensaje { get; set; }
        public HomeModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}