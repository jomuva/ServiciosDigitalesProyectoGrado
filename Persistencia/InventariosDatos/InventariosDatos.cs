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



    }
}