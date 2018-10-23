﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automov1.Data;
using AutomovModel.Avisos.Vendedores;

namespace Automov1.Pages.Mantenedores.TiposVendedor
{
    public class DetailsModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public DetailsModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TipoVendedor TipoVendedor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoVendedor = await _context.TipoVendedor.FirstOrDefaultAsync(m => m.TipoVendedorID == id);

            if (TipoVendedor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
