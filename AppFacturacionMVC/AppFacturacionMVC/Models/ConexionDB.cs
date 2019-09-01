using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppFacturacionMVC.Models
{
    public class ConexionDB
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }

        public int ConteoDatos(String sql)
        {
            int retorno = 0;
            Conectar();
            con.Open();                 
            SqlCommand cmd = new SqlCommand(sql, con);
            retorno = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return retorno;
        }

        public List<T> ObtenerDatos<T>(String sql, Func<IDataReader, T> convert)
        {
            Conectar();
            con.Open();
            //lstLector = new List<Lector>();
            List<T> lst = new List<T>();
            //Creamos comando
            SqlCommand comandSql = con.CreateCommand();
            //ejecutamos consulta
            comandSql.CommandText = sql;
            SqlDataReader rdReader = comandSql.ExecuteReader();
            while (rdReader.Read())
            {
                lst.Add(convert(rdReader));
            }
            rdReader.Close();
            con.Close();
            return lst;
        }

        public int PersistirDatos(string sql)
        {
            int i = 0;
            Conectar();
            
            cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return i;
        }
    }
}