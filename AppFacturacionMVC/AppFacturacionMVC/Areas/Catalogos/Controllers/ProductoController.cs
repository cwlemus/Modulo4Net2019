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
    public class ProductoController : Controller
    {
        public Func<IDataReader, Producto> Converted = r => {
            return new Producto()
            {
                IdProducto = int.Parse(r["ID_PRODUCTO"].ToString()),
                NombreProducto = r["PRODUCTO"].ToString(),
                Precio = float.Parse(r["PRECIO"].ToString())                
            };
        };
        // GET: Catalogos/Producto
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BuscaProducto(string search)
        {
            ConexionDB cxn = new ConexionDB();

            List<Producto> cl = cxn.ObtenerDatos<Producto>(Producto.SqlCad("buscarByFiltro", search), Converted).ToList();

            return new JsonResult { Data = cl, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
    }
}