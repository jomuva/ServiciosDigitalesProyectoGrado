using System;
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


        ///// <summary>
        ///// Consulta los tipos de identificación traidos desde la clase UsuarioDatos
        ///// </summary>
        ///// <returns>Lista de Tipos de Identificación</returns>
        //public void InsertarProducto(Inventario inventario, out string resultado, out string tipoResultado)
        //{
        //    productoDatos.InsertarProducto(inventario.producto.id_estado, inventario.producto.categoria.id, inventario.producto.nombre,
        //                                    inventario.producto.precio_costo, inventario.producto.precio_venta,
        //                                    inventario.cantidadExistencias,SessionHelper.GetUser().ToString(),
        //                                    out resultado,out tipoResultado);
        //}

        ///// <summary>
        ///// Consulta los estados del producto
        ///// </summary>
        ///// <returns></returns>
        //public List<EstadoProducto> ConsultarEstadosProducto()
        //{
        //    List<EstadoProducto> Estados = new List<EstadoProducto>();
        //    var estados = productoDatos.ConsultarEstadosProducto();

        //    string dynObj = JsonConvert.SerializeObject(estados);
        //    dynamic dyn = JsonConvert.DeserializeObject(dynObj);

        //    foreach (var data in dyn)
        //    {
        //        Estados.Add(new EstadoProducto
        //        {
        //            id = data.id,
        //            Descripcion = data.Descripcion,
        //        });
        //    }

        //    return Estados;
        //}

        ///// <summary>
        ///// Consulta las categorias de productos
        ///// </summary>
        ///// <returns></returns>
        //public List<CategoriaProducto> ConsultarCategoriasProducto()
        //{
        //    List<CategoriaProducto> categorias = new List<CategoriaProducto>();
        //    var oCategorias = productoDatos.ConsultarCategoriasProducto();

        //    string dynObj = JsonConvert.SerializeObject(oCategorias);
        //    dynamic dyn = JsonConvert.DeserializeObject(dynObj);

        //    foreach (var data in dyn)
        //    {
        //        categorias.Add(new CategoriaProducto
        //        {
        //            id = data.id_categoria,
        //            Descripcion = data.descripcion,
        //        });
        //    }

        //    return categorias;
        //}

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
                    producto = new Producto((string)item.nombre_producto, (int)item.id_producto_inventario),
                    cantidadExistencias = item.cantidad_existencias,
                    fecha = item.fecha_actualizacion_inventario
                });
            }

            return ListaInventarios;
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

        ///// <summary>
        ///// Modifica el producto traido desde el controlador
        ///// </summary>
        ///// <param name="producto"></param>
        ///// <param name="res"></param>
        ///// <param name="tipoRes"></param>
        //public void ModificarProducto(Producto producto, ref string res, ref string tipoRes)
        //{
        //    productoDatos.ModificarProducto
        //                                (
        //                                    producto.id_producto,  producto.nombre, producto.precio_costo, producto.precio_venta,
        //                                    ref res, ref tipoRes
        //                                );
        //}


        ///// <summary>
        ///// Envia el nuevo estado del producto para su modificacion en BD
        ///// </summary>
        ///// <param name="producto"></param>
        ///// <param name="res"></param>
        ///// <param name="tipoRes"></param>
        //public void CambiarEstadoProducto(Producto producto, out string res, out string tipoRes)
        //{
        //    productoDatos.CambiarEstadoProducto(producto.id_estado,producto.id_producto , out res, out tipoRes);
        //}

    }


}