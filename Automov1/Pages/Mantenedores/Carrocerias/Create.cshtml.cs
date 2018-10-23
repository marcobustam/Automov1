using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Automov1.Data;
using AutomovModel.Vehiculos;

namespace Automov1.Pages.Mantenedores.Carrocerias
{
    public class CreateModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public CreateModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Carroceria Carroceria { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Carroceria.Add(Carroceria);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}