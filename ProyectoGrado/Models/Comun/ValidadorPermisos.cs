using Helper;
using Models;
using Models.Comun;
using ServiciosDigitalesProy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistencia.UsuarioDatos;
using Newtonsoft.Json;

namespace Models.Comun
{
    public class ValidadorPermisos
    {
        private static UsuarioDatos usuarioDatos = null;
        public static bool TienePermiso(RolesPermisos valor)
        {
            bool resultado = true;
            object usuario = ValidadorPermisos.Get();
            List<Permiso> permisos = new List<Permiso>();
            Permiso permiso = new Permiso();
            try
            {
                string dynObj = JsonConvert.SerializeObject(usuario);
                dynamic dyn = JsonConvert.DeserializeObject(dynObj);

                foreach (var data in dyn)
                {
                    permisos.Add(new Permiso
                    {
                        idPermiso = data.permiso_id,
                        Descripcion = data.descripcion
                     });
                }
                int va = (int)valor;
                permiso = permisos.Find(x => x.idPermiso == va);

                resultado = permiso == null ? true : false;
            }
            catch(Exception ex)
            {

            }
            return resultado;
        }

        public  static object Get()
        {
            string resultado = "", tipoResultado = "";
            usuarioDatos = new UsuarioDatos();
            object Usuario = usuarioDatos.ConsultarPermisosXUsuario(SessionHelper.GetUser().ToString(),ref resultado,ref tipoResultado);
            return Usuario;
        }
    }
}