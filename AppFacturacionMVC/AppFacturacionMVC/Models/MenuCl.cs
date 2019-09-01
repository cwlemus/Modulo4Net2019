using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AppFacturacionMVC.Models
{
    public class MenuCl
    {
        public Func<IDataReader, MenuCl> Converted;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<MenuItem> MenuItems { get; set; }

        public MenuCl()
        {
            Converted = r => {
                return new MenuCl()
                {
                    Id = int.Parse(r["Id"].ToString()),
                    Nombre = r["Nombre"].ToString()
                };
            };
        }
        public static string SqlCad(string tipo, string filtro)
        {
            string sql = "";
            switch (tipo)
            {
                case "buscarByIdUsuario":
                    sql = String.Format("SELECT * FROM Menu WHERE Usuario='{0}'", filtro);
                    break;
                case "buscarAll":
                    sql = "SELECT * FROM Menu ";
                    break;
            }
            return sql;
        }
    }
}