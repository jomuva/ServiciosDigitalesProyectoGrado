using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class CategoriaElemento
    {
        public CategoriaElemento()
        {
            id = 0;
            Descripcion = "";
        }

        public CategoriaElemento(string descripcion)
        {
            this.Descripcion = descripcion;
        }
        public CategoriaElemento(int id,string descripcion)
        {
            this.id = id;
            this.Descripcion = descripcion;
        }
        public int id { get; set; }
        public string Descripcion { get; set; }
  
    }

    
}
