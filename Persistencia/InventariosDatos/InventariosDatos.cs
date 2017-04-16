using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Persistencia.InventariosDatos
{
    public class InventariosDatos
    {
        private conexion conexion = new conexion();
        public InventariosDatos()
        {

        }
        /// <summary>
        /// consulta el producto por nombre o por codigo y adicional a ello el procedimiento 
        /// almacenado se encarga de actualizar el estado actual del producto segun disponibilidad en inventario
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarInventarioXProducto(string data, ref string resultado, ref string tipoResultado)
        {
        
            int id = 0;
            object users = null;
            bool result = int.TryParse(data, out id);
            try
            {
                if (result == true)
                {
                    var consulta = conexion.conexiones.ConsultarInventarioXCodigoProducto(id).ToList();
                    resultado = "Consulta Exitosa";
                    tipoResultado = "info";

                    return consulta.ToList();
                }
                else
                {
                    var consulta = conexion.conexiones.ConsultarInventarioXNombreProducto(data).ToList();
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
        /// Consulta la cantidad de existencias que hay en el producto indicado
        /// </summary>
        /// <param name="idInventario"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarCantidadXProducto(int idInventario, ref string resultado, ref string tipoResultado)
        {
            object cantidad=null;
            try
            {
                    cantidad = conexion.conexiones.ConsultarCantidadXProducto(idInventario).ToList();
                    resultado = "Consulta Exitosa";
                    tipoResultado = "info";
            }
            catch 
            {
                tipoResultado = "danger";
            }


            return cantidad;

        }

        /// <summary>
        /// Consulta los inventarios en su totalidad
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarInventarios(ref string resultado, ref string tipoResultado)
        {

            object lista = null;
            try
            {
                var productos = conexion.conexiones.ConsultarInventarios().ToList();

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
        /// Consulta el historico del inventario del producto
        /// </summary>
        /// <param name="idInvent"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarHistoricoInventarioX_id(int idInvent,ref string resultado, ref string tipoResultado)
        {

            object lista = null;
            try
            {
                var historico = conexion.conexiones.ConsultarHistoricoInventarioX_id(idInvent).ToList();

                resultado = "Consulta Exitosa";
                tipoResultado = "info";
                return historico.ToList();
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

            return lista;
        }

        /// <summary>
        /// Actualiza el inventario x producto y lo agrega al historico
        /// </summary>
        /// <param name="idInvent"></param>
        /// <param name="idProd"></param>
        /// <param name="Cantidad"></param>
        /// <param name="identifEmpleado"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void ActualizarInventarioXProducto(int idInvent,int idProd,int Cantidad,string identifEmpleado, ref string resultado, ref string tipoResultado)
        {

            try
            {
                conexion.conexiones.ActualizarInventarioProductos(idInvent,idProd,Cantidad,identifEmpleado);

                resultado = "Se ha actualizado el inventario del producto exitosamente";
                tipoResultado = "success";
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

        }

        /// <summary>
        /// Agrega una anotación al historico del inventario segun el ´producto
        /// </summary>
        /// <param name="idInventario"></param>
        /// <param name="identifEmpleado"></param>
        /// <param name="descripcion"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AgregarAnotacionInventario(int idInventario,string identifEmpleado,string descripcion,ref string resultado, ref string tipoResultado)
        {
            try
            {
                conexion.conexiones.AgregarAnotacionHistoricoInventario(identifEmpleado,idInventario,descripcion);
                resultado = "Se ha realizado la anotación al histórico exitosamente";
                tipoResultado = "success";
            }
            catch (Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }
        }

        #region Inventario Bajas
        /// <summary>
        /// Consulta el inventario de las bajas de productos actualizada
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarInventarioBajas(ref string resultado, ref string tipoResultado)
        {

            object lista = null;
            try
            {
                var productos = conexion.conexiones.ConsultarInventarioBajas().ToList();

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
        /// Consulta el historico del inventario de las bajas por producto
        /// </summary>
        /// <param name="idInvent"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public object ConsultarHistoricoInventarioBajasX_id(int idInvent, ref string resultado, ref string tipoResultado)
        {

            object lista = null;
            try
            {
                var historico = conexion.conexiones.ConsultarHistoricoInventarioBajasX_id(idInvent).ToList();

                resultado = "Consulta Exitosa";
                tipoResultado = "info";
                return historico.ToList();
            }
            catch (Exception ex)
            {
                resultado = ex.Message;
                tipoResultado = "danger";
            }

            return lista;
        }

        /// <summary>
        /// se agrega la baja al inventario de bajas
        /// </summary>
        /// <param name="id_prod"></param>
        /// <param name="cantidadBajas"></param>
        /// <param name="identifEmpleado"></param>
        /// <param name="descripcionBaja"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AgregarBaja(int id_prod,int cantidadBajas,string identifEmpleado,string descripcionBaja, ref string resultado, ref string tipoResultado)
        {
            try
            {
                conexion.conexiones.AgregarBajaInventario(id_prod,cantidadBajas,identifEmpleado,descripcionBaja);
                resultado = "Se ha realizado la baja del producto exitosamente";
                tipoResultado = "success";
            }
            catch(Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }
        }

        /// <summary>
        /// agrega una anotacion al historico del inventario de bajas
        /// </summary>
        /// <param name="idInventario"></param>
        /// <param name="identifEmpleado"></param>
        /// <param name="descripcion"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        public void AgregarAnotacionInventarioBajas(int idInventario, string identifEmpleado, string descripcion, ref string resultado, ref string tipoResultado)
        {
            try
            {
                conexion.conexiones.AgregarAnotacionHistoricoInventarioBajas(identifEmpleado, idInventario, descripcion);
                resultado = "Se ha realizado la anotación al histórico exitosamente";
                tipoResultado = "success";
            }
            catch (Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }
        }
        #endregion


    }
}