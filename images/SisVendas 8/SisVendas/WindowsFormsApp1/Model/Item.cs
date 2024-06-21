using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVendas.Model
{
    internal class Item{

        private int idItem;
        private int quantidadeItem;
        private float valorUnitarioItem;
        private float valorTotalItem;

        public int IdItem { 
            get => idItem; 
            set => idItem = value;
        }

        public int QuantidadeItem { 
            get=> quantidadeItem;
            set => quantidadeItem = value;
        }

        public float ValorUnitarioItem { 
            get=> valorUnitarioItem;
            set => valorUnitarioItem = value;
        }
        public float ValorTotalItem { 
            get => valorTotalItem;
            set => valorTotalItem = value;
        }
    }
}
