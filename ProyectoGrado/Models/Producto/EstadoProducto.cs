using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class EstadoProducto
    {
        public EstadoProducto()
        {
            id = 0;
            Descripcion = "";
        }

        public EstadoProducto(int id,string descri)
        {
            this.id = id;
            Descripcion = descri;
        }

        public EstadoProducto(int ide)
        {
            id = ide;
        }
        public EstadoProducto(string desc)
        {
            this.Descripcion = desc;
        }
        public int id { get; set; }
        public string Descripcion { get; set; }
  
    }

    
}
