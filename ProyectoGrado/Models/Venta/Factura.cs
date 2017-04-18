using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiciosDigitalesProy.Models
{
    public class Factura
    {
        public Factura()
        {
            id_factura = 0;
            cliente = new Usuario();
            id_empleado = 0;
            estado = new EstadoFactura();
            listaDetallesSolicitud = new List<DetalleFacturaSolicitud>();
            listaDetallesProducto = new List<DetalleFacturaProducto>();
            fecha = new DateTime();
            total = 0;
            valorPagado = 0;
        }

        public Factura(int id, DateTime fecha)
        {
            this.id_factura = id;
            this.fecha = fecha;
            cliente = new Usuario();
            id_empleado = 0;
            estado = new EstadoFactura();
            listaDetallesSolicitud = new List<DetalleFacturaSolicitud>();
            listaDetallesProducto = new List<DetalleFacturaProducto>();
            total = 0;
        }

      

        public int id_factura { get; set; }
        public Usuario cliente { get; set; }
        public int id_empleado { get; set; }
        public double total { get; set; }
        [RegularExpression(@"^[0-9a-zA-ZáéíóÚ.ÁÉÍÓÚ. ]{1,40}$", ErrorMessage = "El Pago debe ser igual o mayor a cero")]
        public double valorPagado { get; set; }
        public EstadoFactura estado { get; set; }
        public DateTime fecha { get; set; }
        public List<DetalleFacturaSolicitud> listaDetallesSolicitud { get; set; }
        public List<DetalleFacturaProducto> listaDetallesProducto { get; set; }
     
    }


}
