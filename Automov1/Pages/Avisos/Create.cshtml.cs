using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Automov1.Data;
using AutomovModel.Avisos;

namespace Automov1.Pages.Avisos
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
        public Aviso Aviso { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Aviso.Add(Aviso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}