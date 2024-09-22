﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public IndexModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        public IList<Manga> Manga { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Manga = await _context.Mangas
                .Include(m => m.Genero)
                .Include(m => m.Usuario).ToListAsync();
        }
        public async Task<IActionResult>OnPostDeleteAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var manga = await _context.Mangas .FindAsync(id);

            if (manga != null)
            {
               _context.Mangas.Remove(manga);
                await _context.SaveChangesAsync();
            }
            return Page();


        }


    }
}
