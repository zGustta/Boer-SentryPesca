using SisVendas.Controller;
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
    public partial class Categoria : Form
    {
        public Categoria()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txbNomeCategoria.Text == "")
            {
                txbNomeCategoria.Focus();
                MessageBox.Show("Preencha o campo Nome Categoria", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SisVendas.Model.Categoria mCategoria = new SisVendas.Model.Categoria();
                controllerCategoria cCategoria = new controllerCategoria();

                mCategoria.NomeCategoria = txbNomeCategoria.Text.ToUpper();
                string res = cCategoria.novaCategoria(mCategoria);
                MessageBox.Show(res);
                txbNomeCategoria.Text = "";
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbNomeCategoria.Text = "";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
