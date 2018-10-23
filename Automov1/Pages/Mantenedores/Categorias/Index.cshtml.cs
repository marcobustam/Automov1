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
    public class IndexModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public IndexModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Categoria> Categoria { get;set; }

        public async Task OnGetAsync()
        {
            Categoria = await _context.Categoria.ToListAsync();
        }
    }
}
