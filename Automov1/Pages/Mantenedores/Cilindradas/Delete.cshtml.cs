using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automov1.Data;
using AutomovModel.Vehiculos;

namespace Automov1.Pages.Mantenedores.Cilindradas
{
    public class DeleteModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public DeleteModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cilindrada Cilindrada { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cilindrada = await _context.Cilindrada.FirstOrDefaultAsync(m => m.CilindradaID == id);

            if (Cilindrada == null)
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

            Cilindrada = await _context.Cilindrada.FindAsync(id);

            if (Cilindrada != null)
            {
                _context.Cilindrada.Remove(Cilindrada);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
