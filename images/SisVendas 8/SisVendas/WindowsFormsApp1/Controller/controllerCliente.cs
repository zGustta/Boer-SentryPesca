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
    internal class controllerCliente
    {
        public string novoCliente(Cliente mCliente)
        {
            string sql = "INSERT INTO cliente (cpfcliente, nomecliente, rgcliente, nascimentocliente, enderecocliente, telefonecliente, idcidade) " +
                         "VALUES (@cpfcliente, @nomecliente, @rgcliente, @nascimentocliente, @enderecocliente, @telefonecliente, @idcidade);";
            
            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@cpfcliente", mCliente.CpfCliente);
                comm.Parameters.AddWithValue("@nomecliente", mCliente.NomeCliente);
                comm.Parameters.AddWithValue("@rgcliente", mCliente.RgCliente);
                comm.Parameters.AddWithValue("@nascimentocliente", mCliente.NascimentoCliente);
                comm.Parameters.AddWithValue("@enderecocliente", mCliente.EnderecoCliente);
                comm.Parameters.AddWithValue("@telefonecliente", mCliente.TelefoneCliente);
                comm.Parameters.AddWithValue("@idcidade", mCliente.IdCidade);
                comm.ExecuteNonQuery();
                return "Cliente cadastrado com sucesso!";
            }
            catch (NpgsqlException erro)
            {
                return "Erro ao cadastrar Cliente!";
            }
        }
        public NpgsqlDataReader pesquisaClientePorNome(Cliente mCliente)
        {
            string sql = "select c.nomecliente as \"Cliente\", c.cpfcliente as \"CPF\", c.rgcliente as \"RG\", " +
                "c.nascimentocliente \"Data de Nascimento\", c.enderecocliente as \"Endereço\", c.telefonecliente as \"Telefone\"," +
                "cd.nomecidade as \"Cidade\" from cliente c inner join cidade cd on (cd.idcidade = c.idcidade) " +
                "where upper(c.nomecliente) like  @nomecliente";

            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@nomecliente", mCliente.NomeCliente);      
                return comm.ExecuteReader();
            }
            catch (NpgsqlException erro)
            {
                return null;
            }
        }
        public NpgsqlDataReader pesquisaClientePorCPF(Cliente mCliente)
        {
            string sql = "select c.nomecliente as \"Cliente\", c.cpfcliente as \"CPF\", c.rgcliente as \"RG\", " +
                "c.nascimentocliente \"Data de Nascimento\", c.enderecocliente as \"Endereço\", c.telefonecliente as \"Telefone\"," +
                "cd.nomecidade as \"Cidade\" from cliente c inner join cidade cd on (cd.idcidade = c.idcidade) " +
                "where c.cpfcliente =  @cpfcliente";

            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try
            {
                comm.Parameters.AddWithValue("@cpfcliente", mCliente.CpfCliente);
                return comm.ExecuteReader();
            }
            catch (NpgsqlException erro)
            {
                return null;
            }
        }
    }
}
