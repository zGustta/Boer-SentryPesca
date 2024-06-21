using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using SisVendas.Controller;
using Npgsql;

namespace SisVenda
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        decimal preco = 0, total = 0;
        int quantidadeAtual = 0, quantidadeNova = 0;

        private void tsbNovoCliente_Click(object sender, EventArgs e)
        {
            tbcPrincipal.Visible = true;
            
            tbpNovoCliente.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpNovoCliente;

            tbpNovoFornecedor.Parent = null;
            tbpNovoProduto.Parent = null;
            tbpBuscaCliente.Parent = null;
            tbpBuscaProduto.Parent = null;
            tbpNovaVenda.Parent = null;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            carregaCombobox();
        }
        public void carregaCombobox() 
        { 
            controllerCidade cCidade = new controllerCidade();
            NpgsqlDataReader dadosCidade = cCidade.listaCidade();

            controllerCategoria cCategoria = new controllerCategoria();
            NpgsqlDataReader dadosCategoria = cCategoria.listaCategoria();

            controllerMarca cMarca = new controllerMarca();
            NpgsqlDataReader dadosMarca = cMarca.listaMarca();

            controllerFornecedor cFornecedor = new controllerFornecedor();
            NpgsqlDataReader dadosFornecedor = cFornecedor.listaFornecedor();

            DataTable cidade = new DataTable();
            cidade.Load(dadosCidade);

            DataTable categoria = new DataTable();
            categoria.Load(dadosCategoria);

            DataTable marca = new DataTable();
            marca.Load(dadosMarca);

            DataTable fornecedor = new DataTable();
            fornecedor.Load(dadosFornecedor);



            cbbCidadeCliente.DataSource = cidade;
            cbbCidadeCliente.DisplayMember = "nomecidade";
            cbbCidadeCliente.ValueMember = "idcidade";

            cbbCidadeFornecedor.DataSource = cidade;
            cbbCidadeFornecedor.DisplayMember = "nomecidade";
            cbbCidadeFornecedor.ValueMember = "idcidade";

            cbbCategoriaProduto.DataSource = categoria;
            cbbCategoriaProduto.DisplayMember = "nomecategoria";
            cbbCategoriaProduto.ValueMember = "idcategoria";

            cbbMarcaProduto.DataSource = marca;
            cbbMarcaProduto.DisplayMember = "nomemarca";
            cbbMarcaProduto.ValueMember = "idmarca";

            cbbFornecedorProduto.DataSource = fornecedor;
            cbbFornecedorProduto.DisplayMember = "nomefornecedor";
            cbbFornecedorProduto.ValueMember = "cnpjfornecedor";
        }

        private void cbbCidadeCliente_Click(object sender, EventArgs e)
        {
            carregaCombobox();
        }

        private void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            if (ValidarDadosCliente())
            {
                SisVendas.Model.Cliente mCliente = new SisVendas.Model.Cliente();
                controllerCliente cCliente = new controllerCliente();

                mCliente.CpfCliente = Convert.ToInt64(mtbCpfCliente.Text);
                mCliente.NomeCliente = txbNomeCliente.Text;
                mCliente.RgCliente = txbRgCliente.Text;
                mCliente.EnderecoCliente = txbEnderecoCliente.Text;
                mCliente.IdCidade = Convert.ToInt32(cbbCidadeCliente.SelectedValue);
                mCliente.NascimentoCliente = dtpNascimentoCliente.Value;
                mCliente.TelefoneCliente = mtbTelefoneCliente.Text;

                string res = cCliente.novoCliente(mCliente);
                MessageBox.Show(res);
            }                
        }

        private bool ValidarDadosCliente() 
        {
            if (String.IsNullOrWhiteSpace(txbNomeCliente.Text))
            {
                txbNomeCliente.Focus();
                MessageBox.Show("Preencha o campo Nome","Erro!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(mtbCpfCliente.Text))
            {
                mtbCpfCliente.Focus();
                MessageBox.Show("Preencha o campo CPF", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txbRgCliente.Text))
            {
                txbRgCliente.Focus();
                MessageBox.Show("Preencha o campo RG","Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txbEnderecoCliente.Text))
            {
                txbEnderecoCliente.Focus();
                MessageBox.Show("Preencha o campo Endereço","Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(cbbCidadeCliente.Text))
            {
                cbbCidadeCliente.Focus();
                MessageBox.Show("Preencha o campo Cidade", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
            else if (String.IsNullOrWhiteSpace(mtbTelefoneCliente.Text))
            {
                mtbTelefoneCliente.Focus();
                MessageBox.Show("Preencha o campo Telefone", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else 
            {
                return true;
            }
        }

        private void mspiNovoCidade_Click(object sender, EventArgs e)
        {
            Cidade frmCidade = new Cidade();
            frmCidade.ShowDialog();
        }

        private void mspiNovoCategoria_Click(object sender, EventArgs e)
        {
            Categoria frmCategoria = new Categoria();
            frmCategoria.ShowDialog();
        }

        private void mspiNovaMarca_Click(object sender, EventArgs e)
        {
            Marca frmMarca = new Marca();
            frmMarca.ShowDialog();
        }

        private void btnNovaCidadeCliente_Click(object sender, EventArgs e)
        {
            Cidade frmCidade = new Cidade();
            frmCidade.ShowDialog();
        }

        private void mspiNovoFornecedor_Click(object sender, EventArgs e)
        {
            tbcPrincipal.Visible = true;

            tbpNovoFornecedor.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpNovoFornecedor;

            tbpNovoCliente.Parent = null;
            tbpNovoProduto.Parent = null;
            tbpBuscaCliente.Parent = null;
            tbpBuscaProduto.Parent = null;
            tbpNovaVenda.Parent = null;
        }

        private void mspiNovoCliente_Click(object sender, EventArgs e)
        {
            tbcPrincipal.Visible = true;

            tbpNovoCliente.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpNovoCliente;

            tbpNovoFornecedor.Parent = null;
            tbpNovoProduto.Parent = null;
            tbpBuscaCliente.Parent = null;
            tbpBuscaProduto.Parent = null;
            tbpNovaVenda.Parent = null;
        }

        private void btnSalvarFornecedor_Click(object sender, EventArgs e)
        {
            if (ValidarDadosFornecedor())
            {
                SisVendas.Model.Fornecedor mFornecedor = new SisVendas.Model.Fornecedor();
                controllerFornecedor cFornecedor = new controllerFornecedor();

                mFornecedor.CnpjFornecedor = Convert.ToInt64(mtbCnpjFornecedor.Text);
                mFornecedor.NomeFornecedor = txbNomeFornecedor.Text;
                mFornecedor.EnderecoFornecedor = txbEnderecoFornecedor.Text;
                mFornecedor.EmailFornecedor = txbEmailFornecedor.Text;
                mFornecedor.IdCidade = Convert.ToInt32(cbbCidadeFornecedor.SelectedValue);
                mFornecedor.TelefoneFornecedor = mtbTelefoneFornecedor.Text;

                string res = cFornecedor.novoFornecedor(mFornecedor);
                MessageBox.Show(res);
            }
        }
        private bool ValidarDadosFornecedor()
        {
            if (String.IsNullOrWhiteSpace(txbNomeFornecedor.Text))
            {
                txbNomeFornecedor.Focus();
                MessageBox.Show("Preencha o campo Nome", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(mtbCnpjFornecedor.Text))
            {
                mtbCnpjFornecedor.Focus();
                MessageBox.Show("Preencha o campo CNPJ", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txbEnderecoFornecedor.Text))
            {
                txbEnderecoFornecedor.Focus();
                MessageBox.Show("Preencha o campo Endereço", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(cbbCidadeFornecedor.Text))
            {
                cbbCidadeFornecedor.Focus();
                MessageBox.Show("Preencha o campo Cidade", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txbEmailFornecedor.Text))
            {
                txbEmailFornecedor.Focus();
                MessageBox.Show("Preencha o campo E-mail", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(mtbTelefoneFornecedor.Text))
            {
                mtbTelefoneFornecedor.Focus();
                MessageBox.Show("Preencha o campo Telefone", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cbbCidadeFornecedor_Click(object sender, EventArgs e)
        {
            carregaCombobox();
        }

        private void btnNovaCidadeFornecedor_Click(object sender, EventArgs e)
        {
            Cidade frmCidade = new Cidade();
            frmCidade.ShowDialog();
        }

        private void btnLimparCliente_Click(object sender, EventArgs e)
        {            
            txbNomeCliente.Text = "";
            mtbCpfCliente.Text="";
            txbRgCliente.Text = "";
            txbEnderecoCliente.Text="";
            cbbCidadeCliente.Text = "";
            mtbTelefoneCliente.Text = "";
        }

        private void btnLimparFornecedor_Click(object sender, EventArgs e)
        {
            txbNomeFornecedor.Text = "";
            mtbCnpjFornecedor.Text = "";
            txbEnderecoFornecedor.Text ="";
            cbbCidadeFornecedor.Text = "";
            txbEmailFornecedor.Text = "";
            mtbTelefoneFornecedor.Text = "";
        }

        private void btnSairCliente_Click(object sender, EventArgs e)
        {
            tbpNovoCliente.Parent = null;
        }

        private void btnSairFornecedor_Click(object sender, EventArgs e)
        {
            tbpNovoFornecedor.Parent = null;
        }

        private void tsbNovoProduto_Click(object sender, EventArgs e)
        {
            tbcPrincipal.Visible = true;

            tbpNovoProduto.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpNovoProduto;

            tbpNovoFornecedor.Parent = null;
            tbpNovoCliente.Parent = null;
            tbpBuscaCliente.Parent = null;
            tbpBuscaProduto.Parent = null;
            tbpNovaVenda.Parent = null;
        }

        private void mspiNovoProduto_Click(object sender, EventArgs e)
        {
            tbcPrincipal.Visible = true;

            tbpNovoProduto.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpNovoProduto;

            tbpNovoFornecedor.Parent = null;
            tbpNovoCliente.Parent = null;
            tbpBuscaCliente.Parent = null;
            tbpBuscaProduto.Parent = null;
            tbpNovaVenda.Parent = null;
        }

        private void btnSalvarProduto_Click(object sender, EventArgs e)
        {

            if (ValidarDadosProduto())
            {
                SisVendas.Model.Produto mProduto = new SisVendas.Model.Produto();
                controllerProduto cProduto = new controllerProduto();

                mProduto.BarrasProduto = Convert.ToInt64(txbBarrasProduto.Text);
                mProduto.NomeProduto = txbNomeProduto.Text;
                mProduto.DescricaoProduto = txbDescricaoProduto.Text;
                mProduto.CustoProduto = Convert.ToSingle(txbCustoProduto.Text);
                mProduto.PrecoProduto = Convert.ToSingle(txbPrecoProduto.Text);
                mProduto.ValidadeProduto = dtpValidadeProduto.Value;
                mProduto.QuantidadeProduto = Convert.ToInt32(txbQuantidadeProduto.Text);
                mProduto.IdMarca = Convert.ToInt32(cbbMarcaProduto.SelectedValue);
                mProduto.IdCategoria = Convert.ToInt32(cbbCategoriaProduto.SelectedValue);
                mProduto.CnpjForncedor = Convert.ToInt64(cbbFornecedorProduto.SelectedValue);

                string res = cProduto.novoProduto(mProduto);
                MessageBox.Show(res);
            }
        }

        private void btnNovaMarcaProduto_Click(object sender, EventArgs e)
        {
            Marca frmMarca = new Marca();
            frmMarca.ShowDialog();
        }

        private void btnNovaCategoriaProduto_Click(object sender, EventArgs e)
        {
            Categoria frmCategoria = new Categoria();
            frmCategoria.ShowDialog();
        }

        private void btnNovoFornecedorProduto_Click(object sender, EventArgs e)
        {
            tbpNovoFornecedor.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpNovoFornecedor;

        }

        private void cbbMarcaProduto_Click(object sender, EventArgs e)
        {
            carregaCombobox();
        }

        private void cbbCategoriaProduto_Click(object sender, EventArgs e)
        {
            carregaCombobox();
        }

        private void cbbFornecedorProduto_Click(object sender, EventArgs e)
        {
            carregaCombobox();
        }

        private void btnLimparProduto_Click(object sender, EventArgs e)
        {
            txbNomeProduto.Text = "";
            txbBarrasProduto.Text = "";
            txbDescricaoProduto.Text = "";
            txbCustoProduto.Text = "";
            txbPrecoProduto.Text = "";
            txbQuantidadeProduto.Text = "";
            cbbMarcaProduto.Text = "";
            cbbCategoriaProduto.Text ="";
            cbbFornecedorProduto.Text = "";
        }
        private bool ValidarDadosProduto()
        {
            if (String.IsNullOrWhiteSpace(txbNomeProduto.Text))
            {
                txbNomeProduto.Focus();
                MessageBox.Show("Preencha o campo Nome", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txbBarrasProduto.Text))
            {
                txbBarrasProduto.Focus();
                MessageBox.Show("Preencha o campo Barras", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txbDescricaoProduto.Text))
            {
                txbDescricaoProduto.Focus();
                MessageBox.Show("Preencha o campo Descrição", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txbCustoProduto.Text))
            {
                txbCustoProduto.Focus();
                MessageBox.Show("Preencha o campo Custo do produto", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txbPrecoProduto.Text))
            {
                txbPrecoProduto.Focus();
                MessageBox.Show("Preencha o campo Preço do produto", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txbQuantidadeProduto.Text))
            {
                txbQuantidadeProduto.Focus();
                MessageBox.Show("Preencha o campo Quantidade", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(cbbMarcaProduto.Text))
            {
                cbbMarcaProduto.Focus();
                MessageBox.Show("Preencha o campo Marca", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(cbbCategoriaProduto.Text))
            {
                cbbCategoriaProduto.Focus();
                MessageBox.Show("Preencha o campo Categoria", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(cbbFornecedorProduto.Text))
            {
                cbbFornecedorProduto.Focus();
                MessageBox.Show("Preencha o campo Fornecedor", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnSairProduto_Click(object sender, EventArgs e)
        {
            tbpNovoProduto.Parent = null;
        }

        private void btnPesquisarBuscaCliente_Click(object sender, EventArgs e)
        {
            SisVendas.Model.Cliente mCliente = new SisVendas.Model.Cliente();
            controllerCliente cCliente = new controllerCliente();
            NpgsqlDataReader cliente = null;

            if (!String.IsNullOrWhiteSpace(mtbBuscaCliente.Text)) {

                if (rdbNomeBuscaCliente.Checked)
                {
                    mCliente.NomeCliente = mtbBuscaCliente.Text.ToUpper() + "%";
                    cliente = cCliente.pesquisaClientePorNome(mCliente);
                }
                else if (rdbCpfBuscaCliente.Checked)
                {

                    if (mtbBuscaCliente.Text.Length == 11)
                    {
                        mCliente.CpfCliente = long.Parse(mtbBuscaCliente.Text);
                        cliente = cCliente.pesquisaClientePorCPF(mCliente);
                    }
                }                
                dgvBuscaCliente.Columns.Clear();
                dgvBuscaCliente.ColumnCount = cliente.FieldCount;

                for (int i = 0; i < cliente.FieldCount; i++){
                    dgvBuscaCliente.Columns[i].Name = cliente.GetName(i);
                }
                string[] linha = new string[cliente.FieldCount];

                while (cliente.Read()) {
                    for (int i = 0; i < cliente.FieldCount; i++)
                    {
                        linha[i] = cliente.GetValue(i).ToString();
                    }
                    dgvBuscaCliente.Rows.Add(linha);
                }
            }
            else
            {
                MessageBox.Show("Não foi possivel realizar a consulta");
            }

        }

        private void mspiBuscaCliente_Click(object sender, EventArgs e)
        {
            tbcPrincipal.Visible = true;

            tbpBuscaCliente.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpBuscaCliente;

            tbpNovoCliente.Parent = null;
            tbpNovoProduto.Parent = null;
            tbpNovoFornecedor.Parent = null;
            tbpBuscaProduto.Parent = null;
            tbpNovaVenda.Parent = null;
        }

        private void tsbBuscaCliente_Click(object sender, EventArgs e)
        {
            tbcPrincipal.Visible = true;

            tbpBuscaCliente.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpBuscaCliente;

            tbpNovoCliente.Parent = null;
            tbpNovoProduto.Parent = null;
            tbpNovoFornecedor.Parent = null;
            tbpBuscaProduto.Parent = null;
            tbpNovaVenda.Parent = null;
        }

        private void mspiBuscaProduto_Click(object sender, EventArgs e)
        {
            tbcPrincipal.Visible = true;

            tbpBuscaProduto.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpBuscaProduto;

            tbpNovoCliente.Parent = null;
            tbpNovoProduto.Parent = null;
            tbpNovoFornecedor.Parent = null;
            tbpBuscaCliente.Parent = null;
            tbpNovaVenda.Parent = null;
        }

        private void rdbCpfBuscaCliente_Click(object sender, EventArgs e)
        {
            mtbBuscaCliente.Mask = "000,000,000-00";
            mtbBuscaCliente.Text = "";
            dgvBuscaCliente.Columns.Clear();
        }

        private void rdbNomeBuscaCliente_Click(object sender, EventArgs e)
        {
            mtbBuscaCliente.Mask = null;
            mtbBuscaCliente.Text = "";
            dgvBuscaCliente.Columns.Clear();
        }

        private void btnPesquisarBuscaProduto_Click(object sender, EventArgs e)
        {
            SisVendas.Model.Produto mProduto = new SisVendas.Model.Produto();
            controllerProduto cProduto = new controllerProduto();
            NpgsqlDataReader produto = null;

            if (!String.IsNullOrWhiteSpace(mtbBuscaProduto.Text))
            {

                if (rdbNomeBuscaProduto.Checked)
                {
                    mProduto.NomeProduto = mtbBuscaProduto.Text.ToUpper() + "%";
                    produto = cProduto.pesquisaProdutoPorNome(mProduto);
                }
                else if (rdbBarrasBuscaProduto.Checked)
                {
                    mProduto.BarrasProduto = long.Parse(mtbBuscaProduto.Text);
                    produto = cProduto.pesquisaProdutoPorBarras(mProduto);
                    
                }
                dgvBuscaProduto.Columns.Clear();
                dgvBuscaProduto.ColumnCount = produto.FieldCount;

                for (int i = 0; i < produto.FieldCount; i++)
                {
                    dgvBuscaProduto.Columns[i].Name = produto.GetName(i);
                }
                string[] linha = new string[produto.FieldCount];

                while (produto.Read())
                {
                    for (int i = 0; i < produto.FieldCount; i++)
                    {
                        linha[i] = produto.GetValue(i).ToString();
                    }
                    dgvBuscaProduto.Rows.Add(linha);
                }
            }
            else
            {
                MessageBox.Show("Não foi possivel realizar a consulta");
            }
        }

        private void rdbNomeBuscaProduto_Click(object sender, EventArgs e)
        {
            mtbBuscaProduto.Mask = null;
            mtbBuscaProduto.Text = "";
            dgvBuscaProduto.Columns.Clear();
        }

        private void rdbBarrasBuscaProduto_Click(object sender, EventArgs e)
        {
            mtbBuscaProduto.Mask = "0000000000000";
            mtbBuscaProduto.Text = "";
            dgvBuscaProduto.Columns.Clear();
        }

        private void tsbNovaVenda_Click(object sender, EventArgs e)
        {
            tbcPrincipal.Visible = true;

            tbpBuscaProduto.Parent = tbcPrincipal;
            tbpBuscaCliente.Parent = tbcPrincipal;
            tbpNovaVenda.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpNovaVenda;

            tbpNovoCliente.Parent = null;
            tbpNovoProduto.Parent = null;
            tbpNovoFornecedor.Parent = null;
        
        }

        private void mtbCpfClienteNovaVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            SisVendas.Model.Cliente mCliente = new SisVendas.Model.Cliente();
            controllerCliente cCliente = new controllerCliente();

            if (mtbCpfClienteNovaVenda.Text.Length == 11) { 
                if(e.KeyChar == 13) {
                    mCliente.CpfCliente = long.Parse(mtbCpfClienteNovaVenda.Text);
                    NpgsqlDataReader cliente = cCliente.pesquisaClientePorCPF(mCliente);

                    if (!cliente.HasRows) {
                        MessageBox.Show("Cliente não encontrado", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else
                    {
                        while (cliente.Read()) {
                            txbNomeClienteNovaVenda.Text = cliente.GetValue(0).ToString();
                        }
                    }
                }
            }
        }

        private void mspiNovaVenda_Click(object sender, EventArgs e)
        {
            tbcPrincipal.Visible = true;

            tbpBuscaProduto.Parent = tbcPrincipal;
            tbpBuscaCliente.Parent = tbcPrincipal;
            tbpNovaVenda.Parent = tbcPrincipal;
            tbcPrincipal.SelectedTab = tbpNovaVenda;

            tbpNovoCliente.Parent = null;
            tbpNovoProduto.Parent = null;
            tbpNovoFornecedor.Parent = null;
        }

        private void mtbSelecionarProdutoNovaVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            SisVendas.Model.Produto mProduto = new SisVendas.Model.Produto();
            controllerProduto cProduto = new controllerProduto();
            NpgsqlDataReader produto = null;
            if (e.KeyChar == 13)
            {
                if (rdbBarrasProdutoNovaVenda.Checked)
                {
                    mProduto.BarrasProduto = long.Parse(mtbSelecionarProdutoNovaVenda.Text);
                    produto = cProduto.pesquisaProdutoVendaPorBarras(mProduto);
                }
                else if (rdbNomeProdutoNovaVenda.Checked)
                {
                    mProduto.NomeProduto = mtbSelecionarProdutoNovaVenda.Text.ToUpper()+ "%";
                    produto = cProduto.pesquisaProdutoVendaPorNome(mProduto);
                }
                if (!produto.HasRows)
                {
                    MessageBox.Show("Produto não encontrado", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                   
                    dgvSelecionarProdutoNovaVenda.Columns.Clear();
                    dgvSelecionarProdutoNovaVenda.ColumnCount = produto.FieldCount;

                    for (int i = 0; i < produto.FieldCount; i++)
                    {
                        dgvSelecionarProdutoNovaVenda.Columns[i].Name = produto.GetName(i);
                    }
                    string[] linha = new string[produto.FieldCount];

                    while (produto.Read())
                    {
                        for (int i = 0; i < produto.FieldCount; i++)
                        {
                            linha[i] = produto.GetValue(i).ToString();
                        }
                        dgvSelecionarProdutoNovaVenda.Rows.Add(linha);
                    }
                }
            }
        }
       
        private void rdbNomeProdutoNovaVenda_Click(object sender, EventArgs e)
        {
            mtbSelecionarProdutoNovaVenda.Mask = null;
            mtbSelecionarProdutoNovaVenda.Text = "";
            dgvSelecionarProdutoNovaVenda.Columns.Clear();
        }

        private void dgvItensNovaVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            quantidadeAtual = Convert.ToInt32(dgvItensNovaVenda.CurrentRow.Cells[2].Value);
        }

        private void rdbBarrasProdutoNovaVenda_Click(object sender, EventArgs e)
        {
            mtbSelecionarProdutoNovaVenda.Mask = "0000000000000";
            mtbSelecionarProdutoNovaVenda.Text = "";
            dgvSelecionarProdutoNovaVenda.Columns.Clear();
        }

        private void dgvSelecionarProdutoNovaVenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string[] produto =  new string[3];
            produto[0] = dgvSelecionarProdutoNovaVenda.CurrentRow.Cells[0].Value.ToString();
            produto[1] = dgvSelecionarProdutoNovaVenda.CurrentRow.Cells[2].Value.ToString();
            produto[2] = "1";

            preco = decimal.Parse(produto[1]);
            quantidadeAtual = Convert.ToInt32(produto[2]);
            total = decimal.Parse(lblValorTotalItensNovaVenda.Text) + (preco * quantidadeAtual);

            dgvItensNovaVenda.Rows.Add(produto);
            lblValorTotalItensNovaVenda.Text = total.ToString();
            lblValorTotalVendaNovaVenda.Text = total.ToString();
        }

        private void insertItensVenda(object sender, EventArgs e) {
            SisVendas.Model.Venda mVenda = new SisVendas.Model.Venda();
            controllerVenda cVenda = new controllerVenda();

            SisVendas.Model.ItensVenda mItens = new SisVendas.Model.ItensVenda();
            controllerItensVenda cItens = new controllerItensVenda();

            mVenda.DataVenda = DateTime.Now;

            NpgsqlDataReader venda = cVenda.novaVenda(mVenda);

            while (venda.Read()) { 
                mItens.IdVenda = Convert.ToInt32(venda.GetValue(0));
                MessageBox.Show(mItens.IdVenda.ToString());
            }

            for(int l = 0; l < dgvItensNovaVenda.RowCount; l++)
            {
                mItens.BarrasProduto = dgvItensNovaVenda.Rows[l].Cells[0].Value.ToString();
                mItens.QuantidadeItensVenda = Convert.ToInt32(dgvItensNovaVenda.Rows[l], Cell
                    
                    [3].Value);

                mItens.ValorItensVenda = mItens.QuantidadeItensVenda *
                    decimal.Parse(dgvItensNovaVenda.Rows[l].Cells[2].Value.ToString());

                MessageBox.Show(cItens.adicionaItensVenda(mItens));
            }

            mVenda.IdVenda = mItens.IdVenda;
            mVenda.ValorVenda = decimal.Parse(lblValorTotalItensNovaVenda.Text);
            MessageBox.Show(cVenda.atualizaTotalVenda(mVenda));
        }
    }
}
