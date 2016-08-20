using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace ControleHorasExtras
{
    public partial class TelaColaboradores : Form
    {
        Colaborador ObjColaborador = new Colaborador();
        private TelaInicial FormTelaIicial;
        public TelaColaboradores()
        {
            InitializeComponent();
        }

        public TelaColaboradores(TelaInicial InstanciaTelaIicial)
        {
            this.FormTelaIicial = InstanciaTelaIicial;
            InitializeComponent();

        }
        public TelaColaboradores(string ItemSelecionado, TelaInicial InstanciaTelaIicial)
        {
            this.FormTelaIicial = InstanciaTelaIicial;            
            InitializeComponent();
            ObjColaborador.Id = ItemSelecionado;
            CarregaCampos(ItemSelecionado);


        }
        private void TxtSalario_PercaFoco(object sender, EventArgs e)
        {
            if (TxtBxSalario.Text.Trim() != "")
            {
                LabValor.Text = Controles.ConverteMoeda(TxtBxSalario.Text);
            }
        }

        private void ButSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCamposEmbranco())
                {
                    SalvarColaborador();

                    if (!FormTelaIicial.Alteracao && Controles.ValidaMensagem("Colaborador cadastrado com sucesso, deseja cadastrar uma novo?", "Pergunta"))
                    {
                        LimpaCampos();
                        ObjColaborador.Id = null;
                        FormTelaIicial.AtualizaListaColaboradores();
                    }
                    else {
                        FormTelaIicial.AtualizaListaColaboradores();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Métodos

        private void LimpaCampos()
        {
            TxtBxNome.Clear();
            TxtBxSobrenome.Clear();
            TxtBxSalario.Clear();
            LabValor.Text = null;
        }
        private void SalvarColaborador()
        {
            if (ObjColaborador.Id == null) {
                ObjColaborador.Id = Colaborador.RetornaNovoID(FormTelaIicial.ListagemDeDados).ToString(); 
            }
            ObjColaborador.Nome = TxtBxNome.Text;
            ObjColaborador.Sobrenome = TxtBxSobrenome.Text;
            ObjColaborador.Salario = TxtBxSalario.Text;
            AlteraLista();

        }        
        private void AlteraLista()
        {
            Colaborador.AdicionaAlteraColaborador(this.FormTelaIicial.ListagemDeDados, ObjColaborador);
        }
        private void CarregaCampos(string ID)
        {
            List<string> Dados = Colaborador.CarregaUnicoColaborador(this.FormTelaIicial.ListagemDeDados, ID);
            LabId.Text += ID;
            TxtBxNome.Text = Dados[0];
            TxtBxSobrenome.Text = Dados[1];
            TxtBxSalario.Text = Dados[2];
        }

        private Boolean ValidaCamposEmbranco()
        {
            bool retorno = false;
            ProviderValidaCampos.Clear();
            if (String.IsNullOrWhiteSpace(TxtBxNome.Text))
            {
                ProviderValidaCampos.SetError(groupBox1, "Preencha o campo!");
            }
            else if (String.IsNullOrWhiteSpace(TxtBxSalario.Text))
            {                
                ProviderValidaCampos.SetError(groupBox3, "Preencha o campo!");
            }
            else
            {
                ProviderValidaCampos.Clear();
                retorno = true;
            }
            return retorno;

        }
        #endregion

    }
}

