using Npgsql;
using SisVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVendas.Controller
{
    internal class controllerVenda
    {
        public NpgsqlDataReader novaVenda(Venda mVenda) {
            string sql = "insert into venda (cpfcliente, datavenda)" +
                "values(@cpfcliente, @datavenda) returning idvenda;";
            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try {
                comm.Parameters.AddWithValue("@cpfcliente", mVenda.CpfCliente);
                comm.Parameters.AddWithValue("@datavenda", mVenda.DataVenda);
                return comm.ExecuteReader();
            }
            catch (NpgsqlException ex)
            {
                return null;
            }
        }

        public string atualizaTotalVenda (Venda mVenda) {
            string sql = "update venda set totalvenda = @totalvenda where idvenda = @idvenda;";

            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@cpfcliente", mVenda.CpfCliente);
                comm.Parameters.AddWithValue("@datavenda", mVenda.DataVenda);
                return "Venda finalizada!";
            }
            catch (NpgsqlException ex)
            {
                return null;
            }
        }
    }
    }
}
