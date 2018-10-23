using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Automov1.Data;
using AutomovModel.Marcas;

namespace Automov1.Pages.Mantenedores.Modelos
{
    public class EditModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public EditModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Modelo Modelo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Modelo = await _context.Modelo.FirstOrDefaultAsync(m => m.ModeloID == id);

            if (Modelo == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Modelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloExists(Modelo.ModeloID))
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

        private bool ModeloExists(int id)
        {
            return _context.Modelo.Any(e => e.ModeloID == id);
        }
    }
}
