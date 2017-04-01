using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiciosDigitalesProy.Models;
using ServiciosDigitalesProy.Catalogos;
namespace ServiciosDigitalesProy.Controllers
{
    public class ProductosController : Controller
    {

        [HttpGet]
        public ActionResult InsertarProducto()
        {
            Producto user = new Producto();
            user.estadosProducto = new SelectList(CatalogoProductos.GetInstance().ConsultarEstadosProducto(), "id", "Descripcion");
            return View("AdicionarProducto",user);
        }

      
        [HttpPost]
        public ActionResult InsertarProducto(Producto model)
        {

            string resultado = "", tipoResultado = "";
            if (ModelState.IsValid)
            {
                CatalogoProductos.GetInstance().InsertarProducto(model, out resultado, out tipoResultado);

                //List<Usuario> usuarios;
                //usuarios = CatalogoUsuarios.GetInstance().ConsultarClientes("", ref resultado, ref tipoResultado);

                TempData["mensaje"] = resultado;
                TempData["estado"] = tipoResultado;
                return View("Clientes/RespuestaConsultaClientes");
            }

            TempData["mensaje"] = "Por favor verifique los datos ingresados";
            TempData["estado"] = "danger";
            return View("Clientes/AdicionarCliente");

        }



      
    }
}
