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

namespace MangaUs.Pages.PaginasCRUD
{
    public class EditModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public EditModel(MangaUs.Data.MangaDbContext context)
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

            var pagina =  await _context.Paginas.FirstOrDefaultAsync(m => m.PaginaId == id);
            if (pagina == null)
            {
                return NotFound();
            }
            Pagina = pagina;
           ViewData["CapituloId"] = new SelectList(_context.Capitulos, "CapituloId", "CapituloId");
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

            _context.Attach(Pagina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaginaExists(Pagina.PaginaId))
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

        private bool PaginaExists(int id)
        {
            return _context.Paginas.Any(e => e.PaginaId == id);
        }
    }
}
