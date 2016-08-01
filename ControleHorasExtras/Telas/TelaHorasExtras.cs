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
        int TipoTela; // 1 - Novo, 2 - Alteração
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
            NomeColaborador = FormTelaIicial.GridPrincipal.CurrentRow.Cells[0].Value.ToString() +" "+ FormTelaIicial.GridPrincipal.CurrentRow.Cells[1].Value.ToString();
            InitializeComponent();
            LabNomeColaborador.Text = NomeColaborador;
            TipoTela = 1;


        }
        public TelaHorasExtras(string ItemSelecionado, TelaInicial InstanciaTelaIicial)
        {
            this.FormTelaIicial = InstanciaTelaIicial;
            NomeColaborador = FormTelaIicial.GridPrincipal.CurrentRow.Cells[0].Value.ToString();
            InitializeComponent();
            LabNomeColaborador.Text = NomeColaborador;
            LerAquivo(".\\Colaboradores\\" + NomeColaborador + "\\Horas Extras\\", ItemSelecionado + ".txt");
            TipoTela = 2;
        }
        private void ButSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarHoras();
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


            ObjHorasExtras.DataInicial = TxBxDtaInicial.Text;
            ObjHorasExtras.DataFinal = TxBxDtaFinal.Text;
            string DiretorioPadrao = HorasExtras.UrlDiretorio() + NomeColaborador + "\\Horas Extras\\";

            Controles.CriaDiretorio(DiretorioPadrao);
            CriaArquivo(DiretorioPadrao, ObjHorasExtras.DataInicial.Replace("/", "").Replace(":","") + ".txt");


        }



        private void CriaArquivo(string UrlDiretorio, string NomeArquivo)
        {
            StreamWriter Texto;
            string UrlAquivo = UrlDiretorio + NomeArquivo;

            if (NomeColaborador != null && TipoTela == 1)
            {
                if (File.Exists(UrlAquivo))
                {
                    MessageBox.Show("Já Existe o registro " + ObjHorasExtras.DataInicial + ", utlize o direito Alterar no menu Manutenção >> Horas Extras");
                    this.Close();
                    this.FormTelaIicial.AtualizaListaHorasExtras();
                }
                else
                {
                    Texto = File.CreateText(UrlAquivo);
                    Texto.Close();
                    Controles.AlteraArquivo(UrlAquivo, NomeColaborador, false);
                    Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.DataInicial, false);
                    Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.DataFinal, false);
                    if (Controles.ValidaMensagem("Registro cadastrado com sucesso! Deseja cadastrar um novo?", "Responda"))
                    {
                        LimpaCampos();
                    }
                    else
                    {
                        this.Close();
                        this.FormTelaIicial.AtualizaListaHorasExtras();
                    }
                }
            }
            else
            {
                Controles.AlteraArquivo(UrlAquivo, NomeColaborador, true);
                Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.DataInicial, false);
                Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.DataFinal, false);
                MessageBox.Show("Registro " + ObjHorasExtras.DataInicial + " alterado com sucesso!");
                this.Close();
                this.FormTelaIicial.AtualizaListaHorasExtras();
            }
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
