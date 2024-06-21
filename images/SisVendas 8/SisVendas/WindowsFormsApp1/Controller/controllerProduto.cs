using Npgsql;
using SisVendas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisVendas.Controller;

namespace SisVendas.Controller
{
    internal class controllerProduto
    {
        public string novoProduto(Produto mProduto)
        {
            string sql = "INSERT INTO produto(barrasproduto, nomeproduto, validadeproduto, custoproduto, precoproduto, quantidadeproduto, idcategoria, idmarca, descricaoproduto, cnpjfornecedor)" +
                "VALUES (@barrasproduto, @nomeproduto, @validadeproduto, @custoproduto, @precoproduto, @quantidadeproduto, @idcategoria, @idmarca, @descricaoproduto, @cnpjfornecedor);";
            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@barrasproduto", mProduto.BarrasProduto);
                comm.Parameters.AddWithValue("@nomeproduto", mProduto.NomeProduto);
                comm.Parameters.AddWithValue("@validadeproduto", mProduto.ValidadeProduto);
                comm.Parameters.AddWithValue("@custoproduto", mProduto.CustoProduto);
                comm.Parameters.AddWithValue("@precoproduto", mProduto.PrecoProduto);
                comm.Parameters.AddWithValue("@quantidadeproduto", mProduto.QuantidadeProduto);
                comm.Parameters.AddWithValue("@idcategoria", mProduto.IdCategoria);
                comm.Parameters.AddWithValue("@idmarca", mProduto.IdMarca);
                comm.Parameters.AddWithValue("@descricaoproduto", mProduto.DescricaoProduto);
                comm.Parameters.AddWithValue("@cnpjfornecedor", mProduto.CnpjForncedor);
                comm.ExecuteNonQuery();
                return "Produto cadastrado com sucesso!";
            }
            catch (NpgsqlException erro)
            {
                return "Erro ao cadastrar Produto"+ erro;
            }
        }
        public NpgsqlDataReader pesquisaProdutoPorNome(Produto mProduto)
        {
            string sql = "SELECT  p.nomeproduto as \"Nome\", p.barrasproduto as \"Código de Barras\", p.descricaoproduto as \"Descrição\"," +
                "p.validadeproduto as \"Data de Validade\", p.quantidadeproduto as \"Quantidade\", c.nomecategoria as \"Categoria\"," +
                " m.nomemarca as \"Marca\", f.nomefornecedor as \"Fornecedor\" , 'R$ ' || p.custoproduto || ',00' as \"Preço Custo\", " +
                "'R$ ' || p.precoproduto || ',00' as \"Preço Venda\" FROM produto p " +
                "inner join categoria c on (c.idcategoria = p.idcategoria) inner join marca m on m.idmarca = p.idmarca " +
                "inner join fornecedor f ON (f.cnpjfornecedor = p.cnpjfornecedor) " +
                "WHERE upper(p.nomeproduto) LIKE @nomeproduto";

            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@nomeproduto", mProduto.NomeProduto);
                return comm.ExecuteReader();
            }
            catch (NpgsqlException erro)
            {
                return null;
            }
        }
        public NpgsqlDataReader pesquisaProdutoPorBarras(Produto mProduto)
        {
            string sql = "SELECT  p.nomeproduto as \"Nome\", p.barrasproduto as \"Código de Barras\", p.descricaoproduto as \"Descrição\"," +
                "p.validadeproduto as \"Data de Validade\", p.quantidadeproduto as \"Quantidade\", c.nomecategoria as \"Categoria\"," +
                " m.nomemarca as \"Marca\", f.nomefornecedor as \"Fornecedor\" , 'R$ ' || p.custoproduto || ',00' as \"Preço Custo\", " +
                "'R$ ' || p.precoproduto || ',00' as \"Preço Venda\" FROM produto p " +
                "inner join categoria c on (c.idcategoria = p.idcategoria) inner join marca m on m.idmarca = p.idmarca " +
                "inner join fornecedor f ON (f.cnpjfornecedor = p.cnpjfornecedor) " +
                "WHERE p.barrasproduto = @barrasproduto";

            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@barrasproduto", mProduto.BarrasProduto);
                return comm.ExecuteReader();
            }
            catch (NpgsqlException erro)
            {
                return null;
            }
        }
        public NpgsqlDataReader pesquisaProdutoVendaPorNome(Produto mProduto)
        {
            string sql = "SELECT  p.nomeproduto as \"Nome\", p.barrasproduto as \"Código de Barras\"," +                             
                " p.precoproduto as \"Preço Venda\" FROM produto p " +
                "inner join categoria c on (c.idcategoria = p.idcategoria) inner join marca m on m.idmarca = p.idmarca " +
                "inner join fornecedor f ON (f.cnpjfornecedor = p.cnpjfornecedor) " +
                "WHERE upper(p.nomeproduto) LIKE @nomeproduto";

            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@nomeproduto", mProduto.NomeProduto);
                return comm.ExecuteReader();
            }
            catch (NpgsqlException erro)
            {
                return null;
            }
        }

        public NpgsqlDataReader pesquisaProdutoVendaPorBarras(Produto mProduto)
        {
            string sql = "SELECT  p.nomeproduto as \"Nome\", p.barrasproduto as \"Código de Barras\"," +
                "p.precoproduto  as \"Preço Venda\" FROM produto p " +
                "inner join categoria c on (c.idcategoria = p.idcategoria) inner join marca m on m.idmarca = p.idmarca " +
                "inner join fornecedor f ON (f.cnpjfornecedor = p.cnpjfornecedor) " +
                "WHERE p.barrasproduto = @barrasproduto";

            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@barrasproduto", mProduto.BarrasProduto);
                return comm.ExecuteReader();
            }
            catch (NpgsqlException erro)
            {
                return null;
            }
        }
    }
}
