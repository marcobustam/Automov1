using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Automov1.Data;
using AutomovModel.Vehiculos;

namespace Automov1.Pages.Mantenedores.Carrocerias
{
    public class EditModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public EditModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Carroceria Carroceria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Carroceria = await _context.Carroceria.FirstOrDefaultAsync(m => m.CarroceriaID == id);

            if (Carroceria == null)
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

            _context.Attach(Carroceria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarroceriaExists(Carroceria.CarroceriaID))
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

        private bool CarroceriaExists(int id)
        {
            return _context.Carroceria.Any(e => e.CarroceriaID == id);
        }
    }
}
