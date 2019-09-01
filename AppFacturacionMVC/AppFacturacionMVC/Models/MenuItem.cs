using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AppFacturacionMVC.Models
{
    public class MenuItem
    {
        public Func<IDataReader, MenuItem> Converted;
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Accion { get; set; }
        public String Controlador { get; set; }
        public MenuItem()
        {
            Converted = r => {
                return new MenuItem()
                {
                    Id = int.Parse(r["Id"].ToString()),
                    Nombre = r["Nombre"].ToString(),
                    Accion = r["Accion"].ToString(),
                    Controlador = r["Controlador"].ToString()
                };
            };
        }
        public static string SqlCad(string tipo, string filtro)
        {
            string sql = "";
            switch (tipo)
            {
                case "buscarByIdPadre":
                    sql = String.Format("SELECT * FROM MenuItem WHERE IdPadre={0}", int.Parse(filtro));
                    break;
                case "buscarAll":
                    sql = "SELECT * FROM MenuItem ";
                    break;
            }
            return sql;
        }
    }
}