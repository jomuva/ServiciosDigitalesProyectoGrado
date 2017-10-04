using ServiciosDigitalesProy.Catalogos;
using ServiciosDigitalesProy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoGrado.Controllers
{
	public class AppController : ApiController
	{

		private List<Usuario> EmpList = new List<Usuario>();
		public AppController()
		{
			EmpList.Add(new Usuario("1020727312", "Jonathan", "Muñoz"));
			EmpList.Add(new Usuario("1234567890", "Lorena", "Parra"));
			EmpList.Add(new Usuario("1016045777", "Juan Manuel", "Muñoz"));
		}
		// GET api/EmployeeAPI
		public List<Solicitud> GetSolicitudes(string userLogin)
		{
			string resultado = "", tipoResultado = "";
			List<Solicitud> solicitudes = new List<Solicitud>();
			solicitudes = CatalogoSolicitudes.GetInstance().ConsultarSolicitudesXCliente(userLogin,ref resultado, ref tipoResultado);
			return solicitudes;
		}

		// GET api/EmployeeAPI/5
		public int GetAuthLogin(string username,string password)
		{
			string res = "", tipores = "";
			//return EmpList.Find(e => e.identificacion == id);
			CatalogoUsuarios.GetInstance().ValidarAutenticacionLoginAPP(username, password, ref res, ref tipores); 

			//0: ErrorLogin - 1: Ya esta logueado - 2:Exitoso
			return tipores == "danger" ? 0 : tipores == "info" ? 1 : 2;
		}

		// POST api/EmployeeAPI
		public IEnumerable<Usuario> Post(Usuario value)
		{
			EmpList.Add(value);

			return EmpList;
		}

		// DELETE api/EmployeeAPI/5 
		public IEnumerable<Usuario> Delete(string id)
		{
			EmpList.Remove(EmpList.Find(E => E.identificacion == id));
			return EmpList;
		}

		/// <summary>
		/// ////////////////////////////////////////////////////////////////////////////////////
		/// </summary>
		/// <returns></returns>
		// GET api/<controller>
		//public IEnumerable<string> Get()
		//{
		//	return new string[] { "value1", "value2" };
		//}

		//// GET api/<controller>/5
		//public string Get(int id)
		//{
		//	return "value";
		//}

		//// POST api/<controller>
		//public void Post([FromBody]string value)
		//{
		//}

		////// put api/<controller>/5
		////public void put(int id, [frombody]string value)
		////{
		////}

		//// DELETE api/<controller>/5
		//public void Delete(int id)
		//{
		//}
	}
}