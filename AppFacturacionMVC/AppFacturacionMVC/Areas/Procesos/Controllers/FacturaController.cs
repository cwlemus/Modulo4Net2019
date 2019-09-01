using AppFacturacionMVC.Areas.Catalogos.Models;
using AppFacturacionMVC.Areas.Procesos.Models;
using AppFacturacionMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFacturacionMVC.Areas.Procesos.Controllers
{
    public class FacturaController : Controller
    {
        ConexionDB cxn;
        public Func<IDataReader, EncFactura> Converted = f =>
        {
            return new EncFactura()
            {
                IdEncFactura = int.Parse(f["ID_FACTURA"].ToString()),
                Fecha = f["FECHA"].ToString(),
                FormaPago = f["FORMA_PAGO"].ToString(),
                ClienteFactura = new Cliente(int.Parse(f["ID_CLIENTE"].ToString()))
            };
        };
            // GET: Procesos/Factura
        public ActionResult Factura()
        {
            cxn = new ConexionDB();
            ViewBag.NumeroFactura = (cxn.ConteoDatos(EncFactura.SqlCad("FacturaActual", "",(new EncFactura())))+1);
            return View();
        }

        public ActionResult AbrirFactura(int idFactura, string formaPago, string fecha, string idCliente)
        {
            cxn = new ConexionDB();            
            EncFactura ef = new EncFactura()
            {
                IdEncFactura = idFactura,
                FormaPago = formaPago,
                Fecha = fecha,
                ClienteFactura = new Cliente(int.Parse(idCliente.ToString()))
            };
            int respuesta=cxn.PersistirDatos(EncFactura.SqlCad("insertar","",ef));
            return Json(new { res = respuesta }, JsonRequestBehavior.AllowGet);

        }
    }
}