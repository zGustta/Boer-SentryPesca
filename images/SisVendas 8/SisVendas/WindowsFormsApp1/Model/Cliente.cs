using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SisVendas.Model
{
    internal class Cliente{

        private string nomeCliente;
        private BigInteger cpfCliente;
        private string rgCliente;
        private DateTime nascimentoCliente;
        private string enderecoCliente;
        private string telefoneCliente;
        private int idCidade;



        public string NomeCliente{
            get => nomeCliente;
            set => nomeCliente = value;
        }

        public BigInteger CpfCliente { 
            get => cpfCliente;
            set => cpfCliente = value;
        }

        public string RgCliente {
            get => rgCliente;
            set => rgCliente = value;
        }

        public DateTime NascimentoCliente { 
            get => nascimentoCliente;
            set => nascimentoCliente = value;
        }

        public string EnderecoCliente {
            get => enderecoCliente;
            set => enderecoCliente = value;
        }
        public string TelefoneCliente{
            get => telefoneCliente;
            set => telefoneCliente = value;
        }        
        public int IdCidade{
            get => idCidade;
            set => idCidade = value;
        }
    }
}
