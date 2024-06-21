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
    internal class controllerFornecedor
    {
        public string novoFornecedor(Fornecedor mFornecedor)
        {
            string sql = "INSERT INTO Fornecedor (cnpjfornecedor, nomefornecedor, enderecofornecedor, telefonefornecedor,emailfornecedor, idcidade) " +
                         "VALUES (@cnpjfornecedor, @nomefornecedor, @enderecofornecedor, @telefonefornecedor, @emailfornecedor, @idcidade);";

            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@cnpjfornecedor", mFornecedor.CnpjFornecedor);
                comm.Parameters.AddWithValue("@nomefornecedor", mFornecedor.NomeFornecedor);
                comm.Parameters.AddWithValue("@enderecofornecedor", mFornecedor.EnderecoFornecedor);
                comm.Parameters.AddWithValue("@telefonefornecedor", mFornecedor.TelefoneFornecedor);
                comm.Parameters.AddWithValue("@emailfornecedor", mFornecedor.EmailFornecedor);
                comm.Parameters.AddWithValue("@idcidade", mFornecedor.IdCidade);
                comm.ExecuteNonQuery();
                return "Fornecedor cadastrado com sucesso!";
            }
            catch (NpgsqlException erro)
            {
                return "Erro ao cadastrar Fornecedor";
            }
        }
        public NpgsqlDataReader listaFornecedor()
        {
            string sql = "select * from Fornecedor";
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
