using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SisVendas.Model
{
    internal class ItensVenda
    {
        private int idVenda;
        private long barrasProduto;
        private float quantidadeItensVenda;
        private float valorItensVenda;

        public int IdVenda
        {
            get => idVenda;
            set => idVenda = value;
        }

        public long BarrasProduto
        {
            get => barrasProduto;
            set => barrasProduto = value;
        }

        public float QuantidadeItensVenda
        {
            get => quantidadeItensVenda;
            set => quantidadeItensVenda = value;
        }

        public float ValorItensVenda
        {
            get => valorItensVenda;
            set => valorItensVenda = value;
        }
    }
}
