﻿using System.Web;
using System.Web.Optimization;

namespace ProyectoGrado
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Xcore/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Xcore/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Xcore/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/Personalizacion").Include(
                        "~/Xcore/Scripts/PersonalizadosJS.js",
                        "~/Xcore/Scripts/Modales/ModalElemento.js",
                        "~/Xcore/Scripts/jquery-1.10.2",
                        "~/Xcore/Scripts/Formulario/index.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Xcore/Scripts/bootstrap.js",
                      "~/Xcore/Scripts/respond.js",
                      "~/Xcore/Scripts/jquery.dataTables.min.js",
                      "~/Xcore/Scripts/dataTables.bootstrap.min.js",
                      "~/Xcore/Scripts/dataTables.responsive.js",
                      "~/Xcore/Scripts/notify.js",
                      "~/Xcore/Scripts/notify.min.js",
                      "~/Xcore/Scripts/app.js",
                      "~/Xcore/Scripts/vendor.js",
                      "~/Xcore/Scripts/jquery.bootstrap-growl.js",
                      "~/Xcore/Scripts/jquery.bootstrap-growl.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Xcore/Content/bootstrap.css",
                      "~/Xcore/Content/bootstrap.min.css",
                      "~/Xcore/Content/site.css",
                      "~/Xcore/Content/sb-admin.css",
                       "~/Xcore/Content/jquery.dataTables.min.css",
                      "~/Xcore/Content/font-awesome/css/font-awesome.css",
                      "~/Xcore/Content/styleLogin.css",
                      "~/Xcore/Content/font-awesome/css/font-awesome.min.css"));

            //bundles.Add(new StyleBundle("~/Content/css/Formulario").Include(
            //         "~/Xcore/Content/Formulario/bootstrap-theme.min.css",
            //         "~/Xcore/Content/Formulario/bootstrapValidator.min.css",
            //         "~/Xcore/Content/Formulario/style.css"));


        }
    }
}
