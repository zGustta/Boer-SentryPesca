using Npgsql;
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
    internal class controllerCategoria
    {
        public string novaCategoria(Categoria mCategoria)
        {
            string sql = "insert into Categoria(nomecategoria) values (@nomecategoria)";
            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@nomecategoria", mCategoria.NomeCategoria);
                comm.ExecuteNonQuery();
                return "Categoria cadastrada com sucesso!";
            }
            catch (NpgsqlException erro)
            {
                return "Erro ao cadastrar Categoria!";
            }
        }

        public NpgsqlDataReader listaCategoria()
        {
            string sql = "select * from Categoria";
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
