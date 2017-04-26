using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Persistencia.ProductoDatos
{
    public class ProductoDatos
    {
        private conexion conexion = new conexion();
        public ProductoDatos()
        {

        }

        /// <summary>
        /// Objeto conexion.conexionesque genera conexion.conexiones a la base de datos
        /// </summary>

        /// <summary>
        /// agrega el producto a la BD
        /// </summary>
        /// <param name="estadoProd"></param>
        /// <param name="nombre"></param>
        /// <param name="precioCosto"></param>
        /// <param name="precioVenta"></param>
        /// <param name="cantidad"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public object InsertarProducto(int estadoProd, int idCategoria,string nombre, double precioCosto, double precioVenta, 
            int cantidad,string identifEmpleado, int idSucursal, out string resultado, out string tipoResultado)
        {
            object result = null;
            try
            {
                result = conexion.conexiones.InsertarProducto(estadoProd,idCategoria,nombre,Convert.ToDecimal(precioCosto),Convert.ToDecimal(precioVenta),identifEmpleado,cantidad, idSucursal).ToList();
                conexion.conexiones.SaveChanges();

                resultado = "Se ha agregado el producto exitosamente";
                tipoResultado = "success";

            }catch(Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

            return result;
        }

        /// <summary>
        /// Consulta los diferentes estado del producto
        /// </summary>
        /// <returns> lista de estados </returns>
        public object ConsultarEstadosProducto()
        {
            var estadosProd = from es in conexion.conexiones.ESTADO_PRODUCTO

                             select new
                             {
                                 Descripcion = es.descripcion_estado_producto,
                                 id = es.id_estado_producto

                             };
            return estadosProd.ToList();
        }

        /// <summary>
        /// Consulta las Categorias Posibles para productos
        /// </summary>
        /// <returns></returns>
        public object ConsultarCategoriasProducto()
        {
            var estadosProd = conexion.conexiones.ConsultarCategoriasProductos();
            return estadosProd.ToList();
        }


        /// <summary>
        /// consulta el producto por nombre o por codigo y adicional a ello el procedimiento 
        /// almacenado se encarga de actualizar el estado actual del producto segun disponibilidad en inventario
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarProducto(string data, ref string resultado, ref string tipoResultado)
        {
        
            int id = 0;
            object users = null;
            bool result = int.TryParse(data, out id);
            try
            {
                if (result == true)
                {
                    var consulta = conexion.conexiones.ConsultarProductoXCodigo(id).ToList();
                    resultado = "Consulta Exitosa";
                    tipoResultado = "info";

                    return consulta.ToList();
                }
                else
                {
                    var consulta = conexion.conexiones.ConsultarProductoXNombre(data).ToList();
                    resultado = "Consulta Exitosa";
                    tipoResultado = "info";

                    return consulta.ToList();
                }
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }


            return users;

        }

        /// <summary>
        /// Consulta los productos en su totalidad
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarProductos(ref string resultado, ref string tipoResultado)
        {

            object lista = null;
            try
            {
                var productos = conexion.conexiones.ConsultarProductos().ToList();

                resultado = "Consulta Exitosa";
                tipoResultado = "info";
                return productos.ToList();
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

            return lista;
        }

        /// <summary>
        /// Modifica el producto segun su ID
        /// </summary>
        /// <param name="idProd"></param>
        /// <param name="nombre"></param>
        /// <param name="precioCosto"></param>
        /// <param name="precioVenta"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void ModificarProducto(
                     int idProd,string nombre, double precioCosto, double precioVenta,
                     ref string resultado, ref string tipoResultado)
        {
            try
            {
                conexion.conexiones.ActualizarProducto(idProd,nombre,Convert.ToDecimal(precioCosto),Convert.ToDecimal(precioVenta));
                conexion.conexiones.SaveChanges();
                resultado = "Producto Modificado correctamente";
                tipoResultado = "success";
            }
            catch (Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }

        }

        /// <summary>
        /// modifica el estado del producto a Disponible o No Disponible
        /// </summary>
        /// <param name="idEstado"></param>
        /// <param name="identificacion"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void CambiarEstadoProducto(int idEstado, int identificacion, out string res, out string tipoRes)
        {
            try
            {
                conexion.conexiones.CambiarEstadoProducto(identificacion,idEstado);
                conexion.conexiones.SaveChanges();
                res = "Estado del producto actualizado correctamente";
                tipoRes = "success";
            }
            catch (Exception e)
            {
                res = e.Message;
                tipoRes = "danger";
            }
        }

    }
}