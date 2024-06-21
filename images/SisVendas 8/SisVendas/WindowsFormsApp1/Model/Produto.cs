using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SisVendas.Model
{
    internal class Produto{

        private BigInteger barrasProduto;
        private DateTime validadeProduto;
        private string nomeProduto;
        private float custoProduto;
        private float precoProduto;
        private int quantidadeProduto;
        private string descricaoProduto;
        private int idMarca;
        private int idCategoria;
        private BigInteger cnpjForncedor;

        public BigInteger BarrasProduto { 
            get => barrasProduto;
            set => barrasProduto = value;
        }
        public string NomeProduto { 
            get => nomeProduto;
            set => nomeProduto = value;
        }
        public float CustoProduto { 
            get => custoProduto;
            set => custoProduto = value;
        }
        public float PrecoProduto { 
            get => precoProduto;
            set => precoProduto = value;
        }
        public DateTime ValidadeProduto
        {
            get => validadeProduto;
            set => validadeProduto = value;
        }
        public int QuantidadeProduto
        {
            get => quantidadeProduto;
            set => quantidadeProduto = value;
        }
        public string DescricaoProduto
        {
            get => descricaoProduto;
            set => descricaoProduto = value;
        }
        public int IdMarca
        {
            get => idMarca;
            set => idMarca = value;
        }
        public int IdCategoria
        {
            get => idCategoria;
            set => idCategoria = value;
        }
        public BigInteger CnpjForncedor
        {
            get => cnpjForncedor;
            set => cnpjForncedor = value;
        }
    }
}
