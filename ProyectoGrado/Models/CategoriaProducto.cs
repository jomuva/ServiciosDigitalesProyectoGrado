using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class CategoriaProducto
    {
        public CategoriaProducto()
        {
            id = 0;
            Descripcion = "";
        }

        public CategoriaProducto(string descripcion)
        {
            this.Descripcion = descripcion;
        }

        public CategoriaProducto(int id, string descripcion)
        {
            this.id = id;
            this.Descripcion = descripcion;
        }

        public int id { get; set; }
        public string Descripcion { get; set; }
  
    }

    
}
