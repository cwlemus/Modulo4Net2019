using AppFacturacionMVC.Areas.Catalogos.Models;
using AppFacturacionMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppFacturacionMVC.Areas.Procesos.Models
{
    public class EncFactura
    {
        public int IdEncFactura { get; set; }
        public string Fecha { get; set; }
        public string FormaPago { get; set; }
        public Cliente ClienteFactura { get; set; }

        public EncFactura()
        {
        }

        public EncFactura(int idEncFactura, string fecha, string formaPago, Cliente clienteFactura)
        {
            IdEncFactura = idEncFactura;
            Fecha = fecha;
            FormaPago = formaPago;
            ClienteFactura = clienteFactura;
        }

        public static string SqlCad(string tipo, string filtro, EncFactura eF)
        {
            string sql = "";
            switch (tipo)
            {
                case "insertar":
                    sql = String.Format("INSERT INTO ENC_FACTURA (ID_FACTURA,FECHA,FORMA_PAGO,ID_CLIENTE) " +
                        "VALUES ({0},CAST('{1}' AS DATE),'{2}',{3})", eF.IdEncFactura, eF.Fecha, eF.FormaPago, eF.ClienteFactura.IdCliente);
                    break;               
                case "eliminar":
                    sql = String.Format("DELETE FROM ENC_FACTURA WHERE ID='{0}'", eF.IdEncFactura);
                    break;
                case "buscarById":
                    sql = String.Format("SELECT * FROM ENC_FACTURA WHERE ID_FACTURA={0}", int.Parse(filtro));
                    break;
                case "buscarAll":
                    sql = "SELECT * FROM ENC_FACTURA ";
                    break;                
                case "FacturaActual":
                    sql = String.Format("SELECT isnull(max(ID_FACTURA),0) FROM ENC_FACTURA ");
                    break;

            }
            return sql;
        }
    }
}