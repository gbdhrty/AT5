using AT5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AT5.Pages.Usuarios
{
    public class CriarModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; }
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                using (var writer = new StreamWriter("usuarios.txt", true))
                {
                    writer.WriteLine(Usuario.Nome + ";" + Usuario.Email + ";" + Usuario.DataNascimento);
                    return RedirectToPage("/Usuarios/Index");
                }
            }
        }
    }
}
