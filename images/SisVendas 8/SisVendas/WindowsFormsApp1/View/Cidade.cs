using SisVendas.Controller;
using SisVendas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Cidade : Form
    {
        public Cidade()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txbNomeCidade.Text == "")
            {
                txbNomeCidade.Focus();
                MessageBox.Show("Preencha o campo Nome Cidade", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }else{ 
                SisVendas.Model.Cidade mCidade = new SisVendas.Model.Cidade();
                controllerCidade cCidade = new controllerCidade();

                mCidade.NomeCidade = txbNomeCidade.Text.ToUpper();
                string res = cCidade.novaCidade(mCidade);
                MessageBox.Show(res);
                txbNomeCidade.Text = "";
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbNomeCidade.Text = "";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
