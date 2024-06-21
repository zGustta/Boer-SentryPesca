using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVendas.Model
{
    internal class Venda{
        private int idVenda;
        private float valorVenda;
        private DateTime dataVenda;
        private long cpfCliente;

        public int IdVenda{
            get => idVenda;
            set => idVenda = value;
        }
        
        public float ValorVenda { 
            get => valorVenda; 
            set => valorVenda = value;
        }

        public DateTime DataVenda { 
            get => dataVenda; 
            set => dataVenda = value;
        }

        public long CpfCliente { 
            get => cpfCliente;
            set => cpfCliente = value;
        }
    }
}
