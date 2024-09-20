using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MangaUs.Data;
using MangaUs.Models;

namespace MangaUs.Pages.PaginasCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public DeleteModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pagina Pagina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagina = await _context.Paginas.FirstOrDefaultAsync(m => m.PaginaId == id);

            if (pagina == null)
            {
                return NotFound();
            }
            else
            {
                Pagina = pagina;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagina = await _context.Paginas.FindAsync(id);
            if (pagina != null)
            {
                Pagina = pagina;
                _context.Paginas.Remove(Pagina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
