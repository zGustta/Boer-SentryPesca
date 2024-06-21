using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisVendas.Model
{
    internal class Cidade{
        
        private int idCidade;
        private string nomeCidade;

        public int IdCidade { 
            get => idCidade; 
            set => idCidade = value;
        } 

        public string NomeCidade{
            get => nomeCidade;
            set => nomeCidade = value;
        }

    }
}
