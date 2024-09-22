using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MangaUs.Data;
using MangaUs.Models;

namespace MangaUS.Pages.GeneroCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public DetailsModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        public Genero Genero { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos.FirstOrDefaultAsync(m => m.GeneroId == id);
            if (genero == null)
            {
                return NotFound();
            }
            else
            {
                Genero = genero;
            }
            return Page();
        }
    }
}
