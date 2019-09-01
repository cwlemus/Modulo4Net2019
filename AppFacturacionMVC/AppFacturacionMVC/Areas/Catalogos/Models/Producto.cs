using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppFacturacionMVC.Areas.Catalogos.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public String NombreProducto { get; set; }
        public float Precio { get; set; }

        public static string SqlCad(string tipo, string filtro)
        {
            string sql = "";
            switch (tipo)
            {
                case "buscarById":
                    sql = String.Format("SELECT * FROM PRODUCTO WHERE ID_PRODUCTO={0}", int.Parse(filtro));
                    break;
                case "buscarAll":
                    sql = "SELECT * FROM PRODUCTO ";
                    break;
                case "buscarByFiltro":
                    sql = String.Format("SELECT * FROM PRODUCTO WHERE ID_PRODUCTO LIKE '%{0}%' OR PRODUCTO LIKE '%{0}%' OR PRECIO LIKE '%{0}%'", filtro);
                    break;
            }
            return sql;
        }
    }
}