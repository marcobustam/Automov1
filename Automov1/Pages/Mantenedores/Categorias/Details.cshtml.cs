using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automov1.Data;
using AutomovModel.Categorias;

namespace Automov1.Pages.Mantenedores.Categorias
{
    public class DetailsModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public DetailsModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categoria.FirstOrDefaultAsync(m => m.CategoriaID == id);

            if (Categoria == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
