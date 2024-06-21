using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SisVendas.Model
{
    internal class Fornecedor {
        private string nomeFornecedor;
        private BigInteger cnpjFornecedor;
        private string enderecoFornecedor;
        private string telefoneFornecedor;
        private string emailFornecedor;
        private int idCidade;

        public string NomeFornecedor {
            get => nomeFornecedor;
            set => nomeFornecedor = value;
        }

        public BigInteger CnpjFornecedor {
            get => cnpjFornecedor;
            set => cnpjFornecedor = value;
        }
        public string EnderecoFornecedor{
            get => enderecoFornecedor;
            set => enderecoFornecedor = value;
        }
        public string TelefoneFornecedor{
            get => telefoneFornecedor;
            set => telefoneFornecedor = value;
        }
        public string EmailFornecedor{
            get => emailFornecedor;
            set => emailFornecedor = value;
        }
        public int IdCidade{
            get => idCidade;
            set => idCidade = value;
        }
    }

    

}
