using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ProyectoGrado.Catalogos;
using ProyectoGrado.Tags;

namespace ServiciosDigitalesProy.Controllers
{
    [Autenticado]
    public class InventariosController : Controller
    {

        [HttpGet]
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
        public ActionResult ConsultarInventarios()
        {
            return View("ConsultarInventarios");
        }

       
        [HttpPost]
        public ActionResult ConsultarInventarios(string identificacion)
        {

            string resultado = "", tipoResultado = "";
            List<Inventario> inventarios;
            inventarios = CatalogoInventarios.GetInstance().ConsultarInventarios(identificacion, ref resultado, ref tipoResultado);
            TempData["identificacionConsulta"] = identificacion;
            TempData["mensaje"] = resultado;
            TempData["estado"] = tipoResultado;
            if (tipoResultado == "danger")
            {
                return View("ConsultarProductos");
            }
            else
            {
                return View("RespuestaConsultaInventarios", inventarios);
            }
        }

        [HttpGet]
        public ActionResult ConsultarHistoricoInventarios(int id)
        {
            string resultado = "", tipoResultado = "";
            List<HistoricoInventario> historicos= CatalogoInventarios.GetInstance().ConsultarHistoricoInventarioX_id(id,ref resultado,ref tipoResultado);
            ViewBag.idInventario = id;
            return View(historicos);
        }




    }
}
