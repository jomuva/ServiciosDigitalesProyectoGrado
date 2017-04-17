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
        }

      

        public int id_factura { get; set; }
        public Usuario cliente { get; set; }
        public int id_empleado { get; set; }
        public EstadoFactura estado { get; set; }
        public DateTime fecha { get; set; }
        public List<DetalleFacturaSolicitud> listaDetallesSolicitud { get; set; }
        public List<DetalleFacturaProducto> listaDetallesProducto { get; set; }
     
    }


}
