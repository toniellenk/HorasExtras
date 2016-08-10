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

        public TelaHorasExtras(string ItemSelecionado)
        {
            this.NomeColaborador = ItemSelecionado;
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
                        NomeColaborador = FormTelaIicial.GridPrincipal.CurrentRow.Cells[0].Value.ToString() + " " + FormTelaIicial.GridPrincipal.CurrentRow.Cells[1].Value.ToString();
                        break;
                    }
                case "HorasExtras":
                    {

                        ObjHorasExtras.IdHoraExtra = HorasExtras.RetornaNovoID(FormTelaIicial.ListagemColaborador).ToString();
                        LabID.Text += ObjHorasExtras.IdHoraExtra;
                        
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            InitializeComponent();
        }
        public TelaHorasExtras(TelaInicial InstanciaTelaIicial, bool Alteracao = true)
        {
            this.FormTelaIicial = InstanciaTelaIicial;
            InitializeComponent();
            ObjHorasExtras.IdHoraExtra = FormTelaIicial.GridPrincipal.CurrentRow.Cells[0].Value.ToString();
            CarregaCampos(ObjHorasExtras.IdHoraExtra.Trim());
            this.Alteracao = Alteracao;

        }
        private void ButSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarHoras();
                FormTelaIicial.AtualizaListaHorasExtras();
                this.Close();
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
            if (!Alteracao)
            {
                ObjHorasExtras.IdColaborador = FormTelaIicial.GridPrincipal.CurrentRow.Cells[1].Value.ToString();
            }
            ObjHorasExtras.DataInicial = TxBxDtaInicial.Text;
            ObjHorasExtras.DataFinal = TxBxDtaFinal.Text;
            HorasExtras.AdicionaAlteraHoraExtra(FormTelaIicial.ListagemColaborador, ObjHorasExtras, Alteracao);
        }

        private void CarregaCampos(string ID) {
            List<string> Dados = HorasExtras.CarregaUnicaHoraExtra(FormTelaIicial.ListagemColaborador, ID);

            ObjHorasExtras.IdColaborador = Dados[0];
            ObjHorasExtras.DataInicial = Dados[2];
            ObjHorasExtras.DataFinal = Dados[3];


            LabID.Text += ID;
            LabNomeColaborador.Text = FormTelaIicial.GridPrincipal.CurrentRow.Cells[2].Value.ToString() + " " + FormTelaIicial.GridPrincipal.CurrentRow.Cells[3].Value.ToString();
            TxBxDtaInicial.Text = ObjHorasExtras.DataInicial;
            TxBxDtaFinal.Text = ObjHorasExtras.DataFinal;


        }


        private void LerAquivo(string UrlDiretorio, string NomeArquivo)
        {
            StreamReader Texto;
            string UrlAquivo = UrlDiretorio + NomeArquivo;

            if (File.Exists(UrlAquivo))
            {
                Texto = File.OpenText(UrlAquivo);
                Texto.ReadLine();
                TxBxDtaInicial.Text = Texto.ReadLine();
                TxBxDtaFinal.Text = Texto.ReadLine();
                Texto.Close();
            }
            else
            {
                MessageBox.Show("Não existe o arquivo " + NomeArquivo + " no diretório " + UrlDiretorio);
            }
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

    }
}
