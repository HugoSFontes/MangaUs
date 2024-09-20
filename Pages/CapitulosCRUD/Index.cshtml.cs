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
    public class IndexModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public IndexModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        public IList<Capitulo> Capitulo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Capitulo = await _context.Capitulos
                .Include(c => c.Manga).ToListAsync();
        }
    }
}
