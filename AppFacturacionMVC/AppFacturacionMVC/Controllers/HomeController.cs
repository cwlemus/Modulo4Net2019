using AppFacturacionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppFacturacionMVC.Controllers
{
    public class HomeController : Controller
    {
        ConexionDB cxn;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BuscarProducto()
        {
            return PartialView("_BuscarProducto");
        }

        public ActionResult BuscarCliente()
        {
            return PartialView("_BuscarCliente");
        }

        public ActionResult Menu()
        {
            cxn = new ConexionDB();
            MenuItem menus = new MenuItem();
            List<MenuItem> subMenus = null;
            List<MenuCl> lstMenu = cxn.ObtenerDatos<MenuCl>(MenuCl.SqlCad("buscarByIdUsuario", "clemus"), (new MenuCl()).Converted);
            foreach (MenuCl mn in lstMenu)
            {
                subMenus = new List<MenuItem>();
                subMenus = cxn.ObtenerDatos<MenuItem>(MenuItem.SqlCad("buscarByIdPadre", mn.Id.ToString()), (new MenuItem()).Converted);
                mn.MenuItems = subMenus;
            }

            return PartialView("_Menu", lstMenu);
        }
    }
}