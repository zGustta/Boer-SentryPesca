using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SisVendas.Controller
{
    internal class Connection
    {
        static string Server = "localhost";
        static string Database = "SisVendas";
        static string User = "postgres";
        static string Password = "123456";
        static string Port = "5432";

        NpgsqlConnection connection = null;

        string conn = "Server="+Server+";Port="+Port+";UserID="+User+";password="+Password+";Database="+Database+";";

        public NpgsqlConnection Conectar() {
            try{
                connection = new NpgsqlConnection(conn);
                connection.Open();
                return connection;
            }catch (NpgsqlException ex){
                return null;
            }
            
        }
        public NpgsqlConnection Desconectar(){
            try {
                connection.Close();
                return connection;
            }catch(NpgsqlException ex){
                return null;
            }            
        }
    }
}
