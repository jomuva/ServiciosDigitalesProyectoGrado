using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Persistencia.UsuarioDatos
{
    public class ProductoDatos
    {

        public ProductoDatos()
        {

        }

        /// <summary>
        /// Objeto conexionque genera conexion a la base de datos
        /// </summary>
        private bdServiciosDigitalesProyEntities conexion = new bdServiciosDigitalesProyEntities();

        /// <summary>
        /// Método de consulta de los tipos de identificacion en BD
        /// </summary>
        public void InsertarProducto(int estadoProd, string nombre, double precioCosto, double precioVenta, 
            int cantidad, out string resultado, out string tipoResultado)
        {
            try
            {
                conexion.InsertarProducto(estadoProd,nombre,Convert.ToDecimal(precioCosto),Convert.ToDecimal(precioVenta),cantidad);
                conexion.SaveChanges();

                resultado = "Se ha insertado el producto exitosamente";
                tipoResultado = "success";

            }catch(Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }
            
        }

        /// <summary>
        /// Consulta los diferentes estado del producto
        /// </summary>
        /// <returns> lista de estados </returns>
        public object ConsultarEstadosProducto()
        {
            var estadosProd = from es in conexion.ESTADO_PRODUCTO

                             select new
                             {
                                 Descripcion = es.descripcion_estado_producto,
                                 id = es.id_estado_producto

                             };
            return estadosProd.ToList();
        }

    }
}