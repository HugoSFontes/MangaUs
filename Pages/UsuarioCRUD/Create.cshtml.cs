using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MangaUs.Data;
using MangaUs.Models;

namespace MangaUS.Pages.UsuarioCRUD
{
    public class CreateModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public CreateModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Usuario.DtCriacao = DateTime.Now;
            Usuario.TipoUsuario = "Leitor";
            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
