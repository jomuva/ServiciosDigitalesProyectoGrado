﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistencia.InventariosDatos;
using Newtonsoft.Json;
using ServiciosDigitalesProy.Models;
using Helper;

namespace ProyectoGrado.Catalogos
{
    public class CatalogoInventarios
    {
        private static CatalogoInventarios catalogoInventarios = null;
        private static InventariosDatos inventariosDatos = null;

        public CatalogoInventarios()
        {
            inventariosDatos = new InventariosDatos();
        }

        /// <summary>
        /// Obtiene la instancia creada del catalogo de clientes
        /// </summary>
        /// <returns>CatalogoClientes</returns>
        public static CatalogoInventarios GetInstance()
        {
            if (catalogoInventarios == null)
                catalogoInventarios = new CatalogoInventarios();
            return catalogoInventarios;
        }


        /// <summary>
        /// Consulta el total de inventarios o un inventario de algun producto en especial
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<Inventario> ConsultarInventarios(string ident, ref string resultado, ref string tipoResultado)
        {
            object oUsers = null;
            string dynObj;
            dynamic dyn;
            List<Inventario> ListaInventarios = new List<Inventario>();

            if (ident == "" || ident == null)
            {
                oUsers = inventariosDatos.ConsultarInventarios(ref resultado, ref tipoResultado);
            }
            else if (ident != "")
            {
                oUsers = inventariosDatos.ConsultarInventarioXProducto(ident, ref resultado, ref tipoResultado);
            }
            else
                oUsers = null;

            dynObj = JsonConvert.SerializeObject(oUsers);
            dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var item in dyn)
            {
                ListaInventarios.Add(new Inventario
                {
                    id_inventario = item.id_inventario,
                    producto = new Producto((string)item.nombre_producto, (int)item.id_producto_inventario, (string)item.descripcion_estado_producto),
                    cantidadExistencias = item.cantidad_existencias,
                    fecha = item.fecha_actualizacion_inventario,

                });
            }

            return ListaInventarios;
        }



        /// <summary>
        /// TRAE LA CANTIDAD DE EXISTENCIAS DE UN PRODUCTO EN ESPECIAL
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public int ConsultarCantidadProductoXid(int ident, ref string resultado, ref string tipoResultado)
        {
            object oUsers = null;
            string dynObj;
            dynamic dyn;
            int cantidad = 0;

            oUsers = inventariosDatos.ConsultarCantidadProductoXid(ident, ref resultado, ref tipoResultado);

            dynObj = JsonConvert.SerializeObject(oUsers);
            dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var item in dyn)
            {
                cantidad = item;
            }

            return cantidad;
        }

        /// <summary>
        /// Consulta el historico de un inventario segun su id
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<HistoricoInventario> ConsultarHistoricoInventarioX_id(int idInvent, ref string resultado, ref string tipoResultado)
        {
            object oUsers = null;
            string dynObj;
            dynamic dyn;
            List<HistoricoInventario> historicos = new List<HistoricoInventario>();

            oUsers = inventariosDatos.ConsultarHistoricoInventarioX_id(idInvent, ref resultado, ref tipoResultado);

            dynObj = JsonConvert.SerializeObject(oUsers);
            dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var item in dyn)
            {

                historicos.Add(new HistoricoInventario
                {
                    id_inventario = idInvent,
                    fecha = item.fecha,
                    empleado = new Usuario((string)item.apellidos, (string)item.nombres),
                    descripcion = item.descripcion
                });


            }

            return historicos;
        }

        /// <summary>
        /// actualiza el inventario de un producto segun el id enviado
        /// </summary>
        /// <param name="inventario"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void ActualizarInventarioXProducto(Inventario inventario, ref string res, ref string tipoRes)
        {
            inventariosDatos.ActualizarInventarioXProducto
                                        (
                                            inventario.id_inventario, inventario.producto.id_producto, inventario.cantidadExistencias, SessionHelper.GetUser().ToString(),
                                            ref res, ref tipoRes
                                        );
        }



        /// <summary>
        /// Agrega una anotacion al historico de inventario
        /// </summary>
        /// <param name="inventario"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void AgregarAnotacionInventario(Inventario inventario, ref string res, ref string tipoRes)
        {
            inventariosDatos.AgregarAnotacionInventario(
                                    inventario.id_inventario, SessionHelper.GetUser().ToString(),
                                    inventario.historico.descripcion, ref res, ref tipoRes
                                    );

        }

        #region Inventario Bajas
        /// <summary>
        /// Consulta de inventario de productos dados de baja
        /// </summary>
        /// <param name="ident"></param>
        /// <param name="resultado"></param>
        /// <param name="tipoResultado"></param>
        /// <returns></returns>
        public List<Inventario> ConsultarInventarioBajas(ref string resultado, ref string tipoResultado)
        {
            object oUsers = null;
            string dynObj;
            dynamic dyn;
            List<Inventario> ListaInventarios = new List<Inventario>();

            oUsers = inventariosDatos.ConsultarInventarioBajas(ref resultado, ref tipoResultado);

            dynObj = JsonConvert.SerializeObject(oUsers);
            dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var item in dyn)
            {
                ListaInventarios.Add(new Inventario
                {
                    id_inventario = item.id_inventario_bajas,
                    producto = new Producto((string)item.nombre_producto, (int)item.id_producto_inventario),
                    cantidadExistencias = item.cantidad_existencias,
                    fecha = item.fecha_actualizacion_inventario
                });
            }

            return ListaInventarios;
        }


        public List<HistoricoInventario> ConsultarHistoricoInventarioBajasX_id(int idInvent, ref string resultado, ref string tipoResultado)
        {
            object oUsers = null;
            string dynObj;
            dynamic dyn;
            List<HistoricoInventario> historicos = new List<HistoricoInventario>();

            oUsers = inventariosDatos.ConsultarHistoricoInventarioBajasX_id(idInvent, ref resultado, ref tipoResultado);

            dynObj = JsonConvert.SerializeObject(oUsers);
            dyn = JsonConvert.DeserializeObject(dynObj);

            foreach (var item in dyn)
            {

                historicos.Add(new HistoricoInventario
                {
                    id_inventario = idInvent,
                    fecha = item.fecha,
                    empleado = new Usuario((string)item.apellidos, (string)item.nombres),
                    descripcion = item.descripcion
                });


            }

            return historicos;
        }


        /// <summary>
        /// agrega una baja al inventario de bajas y descuenta en el inventario de productos
        /// </summary>
        /// <param name="inventario"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void AgregarBaja(Inventario inventario, ref string res, ref string tipoRes)
        {
            // 1. Consulta la cantidad actual de inventario para comparar
            object oCantidadInventario = inventariosDatos.ConsultarCantidadXProducto(inventario.producto.id_producto, ref res, ref tipoRes);

            string dynObj = JsonConvert.SerializeObject(oCantidadInventario);
            dynamic dyn = JsonConvert.DeserializeObject(dynObj);
            int cantidadInventario = 0;

            foreach (var item in dyn)
            {
                cantidadInventario = Convert.ToInt32(item);
            }
            // Fin 1.

            // 2. compara cantidad de existencias en inventario y si es mayor que la cantidad de bajas
            // solicitada, se realiza la transaccion, de lo contrario se envía msj al usuario
            if (cantidadInventario < inventario.cantidadExistencias)
            {
                res = "No hay cantidad de productos suficientes para realizar la baja";
                tipoRes = "danger";
            }
            else
            {
                inventariosDatos.AgregarBaja
                                            (
                                               inventario.producto.id_producto, inventario.cantidadExistencias,
                                               SessionHelper.GetUser().ToString(), inventario.historico.descripcion,
                                               ref res, ref tipoRes
                                            );
            }
        }

        //Fin 2.

        /// <summary>
        /// Agrega una anotacion al historico de inventario de bajas
        /// </summary>
        /// <param name="inventario"></param>
        /// <param name="res"></param>
        /// <param name="tipoRes"></param>
        public void AgregarAnotacionInventarioBajas(Inventario inventario, ref string res, ref string tipoRes)
        {
            inventariosDatos.AgregarAnotacionInventarioBajas(
                                    inventario.id_inventario, SessionHelper.GetUser().ToString(),
                                    inventario.historico.descripcion, ref res, ref tipoRes
                                    );

        }
    }

    #endregion

}