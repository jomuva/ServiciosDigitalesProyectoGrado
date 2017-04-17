using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class Producto
    {
        public Producto()
        {
            id_producto = 0;
            nombre = "";
            //id_estado = 0;
            EstadoProducto estado = new EstadoProducto();
            precio_costo = 0;
            precio_venta = 0;
        }


        public Producto(string nombre, int id)
        {
            this.nombre = nombre;
            this.id_producto = id;
        }

        public Producto(string nombre, int id, string descrEstado)
        {
            this.nombre = nombre;
            this.id_producto = id;
            this.estado= new EstadoProducto(descrEstado);
        }
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "Los Caracteres especiales no son permitidos.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"Nombres\" es obligatorio.")]
        public string nombre { get; set; }
        //public int id_estado { get; set; }

        public EstadoProducto estado { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"precio_costo\" es obligatorio.")]
        public double precio_costo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo de \"precio_venta\" es obligatorio.")]
        public double precio_venta { get; set; }

        public int id_producto { get; set; }

        public string cantid { get; set; }
        public CategoriaProducto categoria { get; set; }

        public SelectList estadosProducto { get; set; }

        public SelectList categoriasProductoSelect { get; set; }

    }

    
}
