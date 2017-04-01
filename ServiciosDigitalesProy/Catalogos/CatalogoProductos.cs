using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosDigitalesProy.Models;
using Persistencia.UsuarioDatos;
using Newtonsoft.Json;

namespace ServiciosDigitalesProy.Catalogos
{
    public class CatalogoProductos
    {
        private static CatalogoProductos catalogoProductos = null;
        private static ProductoDatos productoDatos = null;

        public CatalogoProductos()
        {
            productoDatos = new ProductoDatos();
        }

        /// <summary>
        /// Obtiene la instancia creada del catalogo de clientes
        /// </summary>
        /// <returns>CatalogoClientes</returns>
        public static CatalogoProductos GetInstance()
        {
            if (catalogoProductos == null)
                catalogoProductos = new CatalogoProductos();
            return catalogoProductos;
        }

       
        /// <summary>
        /// Consulta los tipos de identificación traidos desde la clase UsuarioDatos
        /// </summary>
        /// <returns>Lista de Tipos de Identificación</returns>
        public void InsertarProducto(Producto producto, out string resultado, out string tipoResultado)
        {
            productoDatos.InsertarProducto( producto.id_estado,producto.nombre,
                                            producto.precio_costo,producto.precio_venta,
                                            producto.inventario.cantidadExistencias,
                                            out resultado,out tipoResultado);
        }

        /// <summary>
        /// Consulta los estados del producto
        /// </summary>
        /// <returns></returns>
        public List<EstadoProducto> ConsultarEstadosProducto()
        {
            List<EstadoProducto> Estados = new List<EstadoProducto>();
            var estados = productoDatos.ConsultarEstadosProducto();

            string dynObj = JsonConvert.SerializeObject(estados);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var data in dyn)
            {
                Estados.Add(new EstadoProducto
                {
                    id = data.id,
                    Descripcion = data.Descripcion,
                });
            }

            return Estados;
        }

    }


}