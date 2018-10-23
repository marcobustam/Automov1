using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Automov1.Data;
using AutomovModel.Avisos;

namespace Automov1.Pages.Avisos
{
    public class EditModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public EditModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Aviso Aviso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Aviso = await _context.Aviso.FirstOrDefaultAsync(m => m.AvisoID == id);

            if (Aviso == null)
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

            _context.Attach(Aviso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvisoExists(Aviso.AvisoID))
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

        private bool AvisoExists(int id)
        {
            return _context.Aviso.Any(e => e.AvisoID == id);
        }
    }
}
