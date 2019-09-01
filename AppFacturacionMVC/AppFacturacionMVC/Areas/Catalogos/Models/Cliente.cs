using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AppFacturacionMVC.Areas.Catalogos.Models
{
  
    public class Cliente
    {
       
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        //  public Func<IDataReader, Cliente> Converted;

        public Cliente()
        {
            
        }


        public Cliente(int idCliente)
        {
            this.IdCliente = idCliente;
        }

        public static string SqlCad(string tipo, string filtro)
        {
            string sql = "";
            switch (tipo)
            {
                case "buscarById":
                    sql = String.Format("SELECT * FROM Cliente WHERE IdCliente={0}", int.Parse(filtro));
                    break;
                case "buscarAll":
                    sql = "SELECT * FROM Cliente ";
                    break;
                case "buscarByFiltro":
                    sql = String.Format("SELECT * FROM Cliente WHERE ID_CLIENTE LIKE '%{0}%' OR  NOMBRE LIKE '%{0}%' OR APELLIDO LIKE '%{0}%' OR TELEFONO LIKE '%{0}%'",filtro);
                    break;
            }
            return sql;
        }
    }

}