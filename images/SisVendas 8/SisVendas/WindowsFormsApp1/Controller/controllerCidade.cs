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
    internal class controllerCidade
    {
        public string novaCidade(Cidade mCidade) {
            string sql = "insert into cidade(nomecidade) values (@nomecidade)";
            Connection conexao = new Connection();
            NpgsqlConnection conn = conexao.Conectar();
            NpgsqlCommand comm = new NpgsqlCommand(sql, conn);

            try {
                comm.Parameters.AddWithValue("@nomecidade", mCidade.NomeCidade);
                comm.ExecuteNonQuery();
                return "Cidade cadastrada com sucesso!";
            }catch(NpgsqlException erro)
            {
                return "Erro ao cadastrar cidade!";
            }
        }

        public NpgsqlDataReader listaCidade() {
            string sql = "select * from cidade";
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
