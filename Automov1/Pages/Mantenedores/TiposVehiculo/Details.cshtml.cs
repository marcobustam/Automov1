using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Automov1.Data;
using AutomovModel.Vehiculos;

namespace Automov1.Pages.Mantenedores.TiposVehiculo
{
    public class DetailsModel : PageModel
    {
        private readonly Automov1.Data.ApplicationDbContext _context;

        public DetailsModel(Automov1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TipoVehiculo TipoVehiculo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoVehiculo = await _context.TipoVehiculo.FirstOrDefaultAsync(m => m.TipoVehiculoID == id);

            if (TipoVehiculo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
