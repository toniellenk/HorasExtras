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
        string NomeColaborador;
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
                //if (ValidaCamposEmbranco)
                //{
                    SalvarHoras();
         //       }
                                 
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);   
            }
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

            FormTelaIicial.AtualizaListaHorasExtras();
            if (Controles.ValidaMensagem("Hora extra cadastrada com sucesso, deseja cadastrar uma nova?", "Pergunta"))
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

        private void TxtBxNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void TelaHorasExtras_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private Boolean ValidaCamposEmbranco(TextBox textbox, ErrorProvider errorprovider)
        {
            if (!String.IsNullOrWhiteSpace(textbox.Text))
            {
                errorprovider.SetError(textbox, "");
                return true;
            }
            else
            {
                errorprovider.SetError(textbox, "Preencha o campo!");
                return false;
            }


        }
    }
}
