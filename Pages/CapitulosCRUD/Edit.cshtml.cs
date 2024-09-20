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

namespace MangaUs.Pages.CapitulosCRUD
{
    public class EditModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public EditModel(MangaUs.Data.MangaDbContext context)
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

            var capitulo =  await _context.Capitulos.FirstOrDefaultAsync(m => m.CapituloId == id);
            if (capitulo == null)
            {
                return NotFound();
            }
            Capitulo = capitulo;
           ViewData["MangaId"] = new SelectList(_context.Mangas, "MangaId", "Autor");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Capitulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapituloExists(Capitulo.CapituloId))
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

        private bool CapituloExists(int id)
        {
            return _context.Capitulos.Any(e => e.CapituloId == id);
        }
    }
}
