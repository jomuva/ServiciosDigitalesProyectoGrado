using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDigitalesProy.Models
{
    public class DetalleFacturaProducto
    {
        public DetalleFacturaProducto()
        {
            id = 0;
            producto = new Producto();
            cantidad = 0;
            total = 0;
        }
       

        public int id { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public double total { get; set; }
    }

    
}
