using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisVendas.Model;
using SisVendas.Controller;
using Npgsql;

namespace SisVendas.Controller
{
    internal class controllerMarca
    {
        public string novaMarca(Marca mMarca)
        {
            string sql = "insert into Marca(nomemarca) values (@nomemarca)";
            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@nomemarca", mMarca.NomeMarca);
                comm.ExecuteNonQuery();
                return "Marca cadastrada com sucesso!";
            }
            catch (NpgsqlException erro)
            {
                return "Erro ao cadastrar Marca!";
            }
        }

        public NpgsqlDataReader listaMarca()
        {
            string sql = "select * from Marca";
            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                return comm.ExecuteReader();
            }
            catch (NpgsqlException erro)
            {
                return null;
            }

        }
    }
}
