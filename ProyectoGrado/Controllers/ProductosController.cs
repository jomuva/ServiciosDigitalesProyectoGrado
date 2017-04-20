using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ProyectoGrado.Catalogos;
using ProyectoGrado.Tags;
using Models.Comun;

namespace ServiciosDigitalesProy.Controllers
{
    [Autenticado]
    public class ProductosController : Controller
    {

        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_adicionar_producto)]
        public ActionResult InsertarProducto()
        {
            Inventario user = new Inventario();
            user.producto.estadosProducto = new SelectList(CatalogoProductos.GetInstance().ConsultarEstadosProducto(), "id", "Descripcion");
            user.producto.categoriasProductoSelect = new SelectList(CatalogoProductos.GetInstance().ConsultarCategoriasProducto(), "id", "Descripcion");

            return View("AdicionarProducto",user);
        }

      
        [HttpPost]
        public ActionResult InsertarProducto(Inventario model)
        {

            string resultado = "", tipoResultado = "";
            string resultado2 = "", tipoResultado2 = "";
            if (ModelState.IsValid)
            {
                CatalogoProductos.GetInstance().InsertarProducto(model, out resultado, out tipoResultado);

                //List<Usuario> usuarios;
                //usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes("", ref resultado, ref tipoResultado);

                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                List<Producto> productos;
                productos = CatalogoProductos.GetInstance().ConsultarProductos("", ref resultado2, ref tipoResultado2);
                return View("RespuestaConsultaProductos", productos);
            }

            TempData["mensaje"] = "Por favor verifique los datos ingresados";
            TempData["estado"] = "danger";
            return View("AdicionarProducto", model);

        }


        [HttpGet]
        public ActionResult ConsultarProductos()
        {
            return View("ConsultarProductos");
        }

       
        [HttpPost]
        public ActionResult ConsultarProductos(string identificacion)
        {

            string resultado = "", tipoResultado = "";
            List<Producto> productos;
            productos = CatalogoProductos.GetInstance().ConsultarProductos(identificacion, ref resultado, ref tipoResultado);
            TempData["identificacionConsulta"] = identificacion;
            if (productos.Count != 0)
            {
                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                if (tipoResultado == "danger")
                {
                    return View("ConsultarProductos");
                }
                else
                {
                    return View("RespuestaConsultaProductos", productos);
                }
            }else
            {
                TempData["mensaje"] = "No se encontraron registro con los parámetros de consulta ingresados";
                TempData["estado"] = "danger";
                return View("ConsultarProductos");
            }
        }

        /// <summary>
        /// Muestra la vista del formulario para actualizar producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_editar_producto)]
        public ActionResult ModificarProducto(string id)
        {
            string resultado = "", tipoResultado = "";
            List<Producto> productos;
            Producto producto;
            productos = CatalogoProductos.GetInstance().ConsultarProductos(id, ref resultado, ref tipoResultado);

            productos.First().estadosProducto = new SelectList(CatalogoProductos.GetInstance().ConsultarEstadosProducto(), "id", "Descripcion");
            producto = productos.First();
            return View("ModificarProducto", producto);
        }

        /// <summary>
        /// Actualiza el producto seleccionado
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateProducto(Producto prod)
        {
            string resultado = "", tipoResultado = "";
            string res="", tipoRes="";
            if (ModelState.IsValid)
            {
                CatalogoProductos.GetInstance().ModificarProducto(prod, ref res, ref tipoRes);
                List<Producto> productos;
                productos = CatalogoProductos.GetInstance().ConsultarProductos((string)TempData.Peek("identificacionConsulta"), ref resultado, ref tipoResultado);
                TempData["mensaje"] = res;
                TempData["estado"] = tipoRes;

                return View("RespuestaConsultaProductos", productos);

            }

            return RedirectToAction("ModificarProducto", prod.id_producto);
        }

        /// <summary>
        /// Muestra la vista para cambiar el estado del producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Permiso(Permiso = RolesPermisos.puede_cambiar_estado_producto)]
        public ActionResult CambiarEstadoProducto(string id)
        {
            string resultado = "", tipoResultado = "";
            List<Producto> productos;
            Producto producto;
            productos = CatalogoProductos.GetInstance().ConsultarProductos(id, ref resultado, ref tipoResultado);
            try
            {
                producto = productos.First();
                producto.estadosProducto = new SelectList(CatalogoProductos.GetInstance().ConsultarEstadosProducto(), "id", "Descripcion");
                return View("CambiarEstadoProducto", producto);
            }
            catch (Exception e)
            {
                resultado = e.Message;
                tipoResultado = "danger";
            }
            return View("CambiarEstadoProducto", new Producto { estadosProducto = new SelectList(CatalogoProductos.GetInstance().ConsultarEstadosProducto(), "id", "Descripcion") });
        }


        ///// <summary>
        ///// Envía el formulario para cambiar el estado del cliente seleccionado
        ///// </summary>
        ///// <param name="usuario"></param>
        ///// <returns></returns>
        [HttpPost]
        public ActionResult ModificarEstadoProducto(Producto producto)
        {
            string res, tipoRes;
            string resultado = "", tipoResultado = "";
            CatalogoProductos.GetInstance().CambiarEstadoProducto(producto, out res, out tipoRes);
            List<Producto> productos;
            productos = CatalogoProductos.GetInstance().ConsultarProductos((string)TempData.Peek("identificacionConsulta"), ref resultado, ref tipoResultado);

            TempData["mensaje"] = res;
            TempData["estado"] = tipoRes;
            return View("RespuestaConsultaProductos", productos);
        }


        [HttpGet]
        public ActionResult VolverDetallesProducto(string iden)
        {
            string resultado = "", tipoResultado = "";
            List<Producto> productos;
            productos = CatalogoProductos.GetInstance().ConsultarProductos(iden, ref resultado, ref tipoResultado);
            return View("RespuestaConsultaProductos", productos);
        }



    }
}
