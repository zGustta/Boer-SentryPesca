using Npgsql;
using SisVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVendas.Controller
{
    internal class controllerItensVenda
    {
        public string adicionaItensVenda(ItensVenda mItens) {

            string sql = "insert into itensvenda(idvenda, codigobarras, quantidadeitensvenda, valortotalitensvenda)" +
                "values(@idvenda, @codigobarras, @quantidadeitensvenda, @valortotalitensvenda;)";

            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try {
                comm.Parameters.AddWithValue("@idvenda", mItens.IdVenda);
                comm.Parameters.AddWithValue("@codigobarras", mItens.BarrasProduto);
                comm.Parameters.AddWithValue("@quantidadeItensVenda", mItens.QuantidadeItensVenda);
                comm.Parameters.AddWithValue("@valortotalItensVenda", mItens.ValorItensVenda);

                return comm.ToString();
            }
            catch (NpgsqlException ex) {

                return null;
            }
        }
    }
}
