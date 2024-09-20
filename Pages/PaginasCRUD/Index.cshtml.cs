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
    public class IndexModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public IndexModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        public IList<Pagina> Pagina { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pagina = await _context.Paginas
                .Include(p => p.Capitulo).ToListAsync();
        }
    }
}
