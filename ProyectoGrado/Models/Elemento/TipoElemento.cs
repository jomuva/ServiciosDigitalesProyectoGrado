using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class TipoElemento
    {
        public TipoElemento()
        {
            id = 0;
            Descripcion = "";
        }

        public TipoElemento(string descripcion)
        {
            this.Descripcion = descripcion;
        }

        public TipoElemento(int id, string descripcion)
        {
            this.id = id;
            this.Descripcion = descripcion;
        }

        public int id { get; set; }
        public string Descripcion { get; set; }
  
    }

    
}
