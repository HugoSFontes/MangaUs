using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MangaUs.Data;
using MangaUs.Models;

namespace MangaUS.Pages.MangaCRUD
{
    public class EditModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public EditModel(MangaUs.Data.MangaDbContext context)
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

            var manga =  await _context.Mangas.FirstOrDefaultAsync(m => m.MangaId == id);
            if (manga == null)
            {
                return NotFound();
            }
            Manga = manga;
           ViewData["GeneroId"] = new SelectList(_context.Generos, "GeneroId", "Nome");
           ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Manga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MangaExists(Manga.MangaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MangaExists(int id)
        {
            return _context.Mangas.Any(e => e.MangaId == id);
        }
    }
}
