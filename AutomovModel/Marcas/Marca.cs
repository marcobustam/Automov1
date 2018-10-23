using System;
using System.Collections.Generic;
using System.Text;

namespace AutomovModel.Marcas
{
    public class Marca
    {
        public int MarcaID { get; set; }
        public string NombreMarca { get; set; }
        public IList<Modelo> ListaModelos { get; set; }
    }
}
