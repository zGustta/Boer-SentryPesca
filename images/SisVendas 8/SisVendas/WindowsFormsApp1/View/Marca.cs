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
    public partial class Marca : Form
    {
        public Marca()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txbNomeMarca.Text == "")
            {
                txbNomeMarca.Focus();
                MessageBox.Show("Preencha o campo Nome Marca", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SisVendas.Model.Marca mMarca = new SisVendas.Model.Marca();
                controllerMarca cMarca = new controllerMarca();

                mMarca.NomeMarca = txbNomeMarca.Text.ToUpper();
                string res = cMarca.novaMarca(mMarca);
                MessageBox.Show(res);
                txbNomeMarca.Text = "";
            }
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbNomeMarca.Text = "";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
