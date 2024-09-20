using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MangaUs.Data;
using MangaUs.Models;

namespace MangaUs.Pages.CapitulosCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public DeleteModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Capitulo Capitulo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitulo = await _context.Capitulos.FirstOrDefaultAsync(m => m.CapituloId == id);

            if (capitulo == null)
            {
                return NotFound();
            }
            else
            {
                Capitulo = capitulo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitulo = await _context.Capitulos.FindAsync(id);
            if (capitulo != null)
            {
                Capitulo = capitulo;
                _context.Capitulos.Remove(Capitulo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
