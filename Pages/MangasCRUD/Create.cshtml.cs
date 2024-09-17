using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MangaUs.Data;
using MangaUs.Models;

namespace MangaUs.Pages.MangasCRUD
{
    public class CreateModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        public CreateModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Manga Manga { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mangas.Add(Manga);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
