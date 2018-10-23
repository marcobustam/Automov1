using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AutomovModel.Avisos.Vendedores;
using AutomovModel.Vehiculos;
using AutomovModel.Categorias;
using AutomovModel.Marcas;
using AutomovModel.Avisos;

namespace Automov1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AutomovModel.Avisos.Vendedores.TipoVendedor> TipoVendedor { get; set; }
        public DbSet<AutomovModel.Vehiculos.TipoVehiculo> TipoVehiculo { get; set; }
        public DbSet<AutomovModel.Categorias.Categoria> Categoria { get; set; }
        public DbSet<AutomovModel.Vehiculos.Carroceria> Carroceria { get; set; }
        public DbSet<AutomovModel.Marcas.Marca> Marca { get; set; }
        public DbSet<AutomovModel.Marcas.Modelo> Modelo { get; set; }
        public DbSet<AutomovModel.Avisos.Aviso> Aviso { get; set; }
        public DbSet<AutomovModel.Vehiculos.Vehiculo> Vehiculo { get; set; }
        public DbSet<AutomovModel.Vehiculos.Cilindrada> Cilindrada { get; set; }
    }
}
