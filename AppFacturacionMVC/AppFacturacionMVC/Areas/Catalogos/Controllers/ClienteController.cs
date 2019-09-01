using AppFacturacionMVC.Areas.Catalogos.Models;
using AppFacturacionMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFacturacionMVC.Areas.Catalogos.Controllers
{
    public class ClienteController : Controller
    {
        public Func<IDataReader, Cliente> Converted = r => {
                return new Cliente()
                {
                     IdCliente = int.Parse(r["ID_CLIENTE"].ToString()),
                    Nombre = r["NOMBRE"].ToString(),
                    Apellido = r["APELLIDO"].ToString(),
                    Telefono = r["TELEFONO"].ToString()
                };
        };

    // GET: Catalogos/Cliente
    public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult BuscaCliente(string search)
        {
            ConexionDB cxn = new ConexionDB();           
            List<Cliente> cl = cxn.ObtenerDatos<Cliente>(Cliente.SqlCad("buscarByFiltro", search), 
                Converted).ToList();
          return new JsonResult { Data = cl, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
          
        }
    }
}