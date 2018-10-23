using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automov1.Data;
using AutomovModel.Avisos;

namespace Automov1.Pages.Avisos
{
    public class DetailsModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public DetailsModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
