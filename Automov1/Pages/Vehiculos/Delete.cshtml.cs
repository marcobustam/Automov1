﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automov1.Data;
using AutomovModel.Vehiculos;

namespace Automov1.Pages.Vehiculos
{
    public class DeleteModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public DeleteModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehiculo Vehiculo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehiculo = await _context.Vehiculo.FirstOrDefaultAsync(m => m.VehiculoID == id);

            if (Vehiculo == null)
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

            Vehiculo = await _context.Vehiculo.FindAsync(id);

            if (Vehiculo != null)
            {
                _context.Vehiculo.Remove(Vehiculo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
