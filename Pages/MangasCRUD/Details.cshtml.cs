using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MangaUs.Data;
using MangaUs.Models;

namespace MangaUs.Pages.MangasCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public DetailsModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

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
    }
}
