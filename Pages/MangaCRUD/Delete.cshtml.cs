using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MangaUs.Data;
using MangaUs.Models;

namespace MangaUS.Pages.MangaCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public DeleteModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Manga Manga { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Mangas.FirstOrDefaultAsync(m => m.MangaId == id);

            if (manga == null)
            {
                return NotFound();
            }
            else
            {
                Manga = manga;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manga = await _context.Mangas.FindAsync(id);
            if (manga != null)
            {
                Manga = manga;
                _context.Mangas.Remove(Manga);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
