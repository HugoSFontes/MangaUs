using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MangaUs.Data;
using MangaUs.Models;

namespace MangaUS.Pages.UsuarioCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public DeleteModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usuario Usuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }
            else
            {
                Usuario = usuario;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                Usuario = usuario;
                _context.Usuarios.Remove(Usuario);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
