using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MangaUs.Data;
using MangaUs.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace MangaUs.Pages.MangasCRUD
{
    public class CreateModel : PageModel
    {
        private readonly MangaUs.Data.MangaDbContext _context;

        [BindProperty]
        public Manga Manga { get; set; }

        // Propriedade para o upload do arquivo
        [BindProperty]
        public IFormFile UploadCapa { get; set; }

        public CreateModel(MangaUs.Data.MangaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile UploadCapa)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Verifica se há um arquivo e se ele é válido
            if (UploadCapa != null && UploadCapa.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await UploadCapa.CopyToAsync(memoryStream);
                    Manga.CapaManga = memoryStream.ToArray(); // Converte o arquivo para byte[]
                }
            }
            else
            {
                ModelState.AddModelError("UploadCapa", "A capa do manga é obrigatória.");
                return Page();
            }

            _context.Mangas.Add(Manga);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}