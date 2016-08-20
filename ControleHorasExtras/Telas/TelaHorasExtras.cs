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

namespace ControleHorasExtras
{
    public partial class TelaHorasExtras : Form
    {
        HorasExtras ObjHorasExtras = new HorasExtras();
        bool CamposValidados = false;
        bool Alteracao = false;

        private TelaInicial FormTelaIicial;
        public TelaHorasExtras()
        {
            InitializeComponent();
        }
        public TelaHorasExtras(TelaInicial InstanciaTelaIicial)
        {

            this.FormTelaIicial = InstanciaTelaIicial;
            InitializeComponent();
            switch (FormTelaIicial.TipoGrid)
            {
                case "Colaborador":
                    {
                        CombBoxColaboradorTelaHora.Visible = false;
                        LabNomeColaborador.Text = FormTelaIicial.GridPrincipal.CurrentRow.Cells[1].Value.ToString() + " " + FormTelaIicial.GridPrincipal.CurrentRow.Cells[2].Value.ToString();
                        ObjHorasExtras.IdColaborador = FormTelaIicial.GridPrincipal.CurrentRow.Cells[0].Value.ToString();
                        ObjHorasExtras.IdHoraExtra = HorasExtras.RetornaNovoID(FormTelaIicial.ListagemDeDados).ToString();
                        break;
                    }
                case "HorasExtras":
                    {                   
                        List<string> ListaColaboradores = Colaborador.CarregaColaboradoresSomenteIDeNomes(FormTelaIicial.ListagemDeDados);
                        CombBoxColaboradorTelaHora.DataSource = ListaColaboradores;
                        LabID.Text += ObjHorasExtras.IdHoraExtra;                        
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        public TelaHorasExtras(TelaInicial InstanciaTelaIicial, bool Alteracao = true)
        {
            this.FormTelaIicial = InstanciaTelaIicial;
            InitializeComponent();
            CombBoxColaboradorTelaHora.Visible = false;
            ObjHorasExtras.IdHoraExtra = FormTelaIicial.GridPrincipal.CurrentRow.Cells[0].Value.ToString();
            CarregaCampos(ObjHorasExtras.IdHoraExtra.Trim());
            this.Alteracao = Alteracao;

        }
        private void ButSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CamposValidados)
                {
                    SalvarHoras();
                }
                                 
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);   
            }
        }

        void maskedTxBxDtaInicial_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
            {
            if (!e.IsValidInput)
            {
                ToolTipCampos.ToolTipTitle = "Data inicial inválida";
                ToolTipCampos.Show("A data deve estar no formato dd/mm/aaaa hh:mm.", groupBox1, 0, -20, 5000);
                ProviderValidaCampos.SetError(TxBxDtaInicial, "Data inválida");
                CamposValidados = false;
                TxBxDtaFinal.Clear();
            }
            else
            {
                DateTime userDate = (DateTime)e.ReturnValue;
                if (userDate > DateTime.Now)
                {
                    ToolTipCampos.ToolTipTitle = "Data inicial inválida";
                    ToolTipCampos.Show("A data inicial não pode ser maior que a data de hoje.", groupBox1, 0, -20, 5000);
                    e.Cancel = true;
                    CamposValidados = false;
                }
                else
                {
                    ProviderValidaCampos.Clear();
                    CamposValidados = true;
                }
            }
        }

        void maskedTxBxDtaFinal_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                ToolTipCampos.ToolTipTitle = "Data final inválida";
                ToolTipCampos.Show("A data final deve estar no formato dd/mm/aaaa hh:mm.", groupBox2, 0, -20, 5000);
                ProviderValidaCampos.SetError(TxBxDtaFinal, "Data inválida");
                TxBxDtaFinal.Clear();
                CamposValidados = false;
            }
            else
            {
                DateTime userDate = (DateTime)e.ReturnValue;
                if (userDate < Convert.ToDateTime(TxBxDtaInicial.Text))
                {
                    ToolTipCampos.ToolTipTitle = "Data final inválida";
                    ToolTipCampos.Show("Data final não pode ser menor que a data inicial", groupBox2, 0, -20, 5000);                    
                    e.Cancel = true;
                    CamposValidados = false;
                }
                else
                {
                    ProviderValidaCampos.Clear();
                    CamposValidados = true;
                }
            }
        }

        void maskedTxBxDtaInicial_KeyDown(object sender, KeyEventArgs e)
        {
            ToolTipCampos.Hide(TxBxDtaInicial);
        }

        void maskedTxBxDtaFinal_KeyDown(object sender, KeyEventArgs e)
        {
            ToolTipCampos.Hide(TxBxDtaFinal);
        }
        #region Métodos

        private void LimpaCampos()
        {
            TxBxDtaInicial.Clear();
            TxBxDtaFinal.Clear();
        }
        private void SalvarHoras()
        {
            if (!Alteracao && FormTelaIicial.TipoGrid == "HorasExtras"){
                string ColaboradorSelecionado = CombBoxColaboradorTelaHora.SelectedItem.ToString();
                var valorLinha = ColaboradorSelecionado.Split('-');
                ObjHorasExtras.IdColaborador = valorLinha[0].Trim();
                ObjHorasExtras.IdHoraExtra = HorasExtras.RetornaNovoID(FormTelaIicial.ListagemDeDados).ToString();
            }
            ObjHorasExtras.DataInicial = TxBxDtaInicial.Text;
            ObjHorasExtras.DataFinal = TxBxDtaFinal.Text;
            HorasExtras.AdicionaAlteraHoraExtra(FormTelaIicial.ListagemDeDados, ObjHorasExtras);

            if (FormTelaIicial.TipoGrid == "HorasExtras") {
                FormTelaIicial.AtualizaListaHorasExtras();
            }

            if (!FormTelaIicial.Alteracao && Controles.ValidaMensagem("Hora extra cadastrada com sucesso, deseja cadastrar uma nova?", "Pergunta"))
            {
                LimpaCampos();
            }
            else {
                this.Close();
            }
        }
        private void CarregaCampos(string ID) {
            List<string> Dados = HorasExtras.CarregaUnicaHoraExtra(FormTelaIicial.ListagemDeDados, ID);

            ObjHorasExtras.IdColaborador = Dados[0];
            ObjHorasExtras.DataInicial = Dados[2];
            ObjHorasExtras.DataFinal = Dados[3];


            LabID.Text += ID;
            LabNomeColaborador.Text = FormTelaIicial.GridPrincipal.CurrentRow.Cells[2].Value.ToString();
            TxBxDtaInicial.Text = ObjHorasExtras.DataInicial;
            TxBxDtaFinal.Text = ObjHorasExtras.DataFinal;


        }


        #endregion

        private void TelaHorasExtras_Load(object sender, EventArgs e)
        {
            this.TxBxDtaInicial.TypeValidationCompleted += new TypeValidationEventHandler(maskedTxBxDtaInicial_TypeValidationCompleted);
            this.TxBxDtaInicial.KeyDown += new KeyEventHandler(maskedTxBxDtaInicial_KeyDown);
            this.TxBxDtaFinal.TypeValidationCompleted += new TypeValidationEventHandler(maskedTxBxDtaFinal_TypeValidationCompleted);
            this.TxBxDtaFinal.KeyDown += new KeyEventHandler(maskedTxBxDtaFinal_KeyDown);
        }


    }
}
