using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automov1.Data;
using AutomovModel.Marcas;

namespace Automov1.Pages.Mantenedores.Marcas
{
    public class DeleteModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public DeleteModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Marca Marca { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Marca = await _context.Marca.FirstOrDefaultAsync(m => m.MarcaID == id);

            if (Marca == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Marca = await _context.Marca.FindAsync(id);

            if (Marca != null)
            {
                _context.Marca.Remove(Marca);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
