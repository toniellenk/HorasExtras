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
        string ItemSelecionado;
        private TelaInicial FormTelaIicial;
        public TelaHorasExtras()
        {
            InitializeComponent();
        }

        public TelaHorasExtras(string ItemSelecionado)
        {
            this.ItemSelecionado = ItemSelecionado;
            InitializeComponent();

        }
        public TelaHorasExtras(TelaInicial InstanciaTelaIicial)
        {
            this.FormTelaIicial = InstanciaTelaIicial;
            InitializeComponent();
            
        }
        public TelaHorasExtras(string ItemSelecionado, TelaInicial InstanciaTelaIicial)
        {
            this.FormTelaIicial = InstanciaTelaIicial;
            this.ItemSelecionado = ItemSelecionado;
            InitializeComponent();
            Controles.LerAquivo(".\\Colaboradores\\" + ItemSelecionado + "\\Dados\\", ItemSelecionado + ".txt");
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


            ObjHorasExtras.DataInicial = "";
            ObjHorasExtras.HoraInicial = "";
            ObjHorasExtras.DataFinal = "";
            ObjHorasExtras.HoraFinal = "";


            Controles.CriaDiretorio(HorasExtras.UrlDiretorio + ObjHorasExtras.DataInicial.Replace("/",""));
            CriaArquivo(HorasExtras.UrlDiretorio, ObjHorasExtras.DataInicial + " " + ObjHorasExtras.HoraInicial + ".txt");


        }



        private void CriaArquivo(string UrlDiretorio, string NomeArquivo)
        {
            StreamWriter Texto;
            string UrlAquivo = UrlDiretorio + NomeArquivo;

            if (ItemSelecionado == null)
            {
                if (File.Exists(UrlAquivo))
                {
                    MessageBox.Show("Já Existe o registro " + ObjHorasExtras.DataInicial + ", utlize o direito Alterar");
                    this.Close();
                    this.FormTelaIicial.AtualizaListaColaboradores();
                }
                else
                {
                    Texto = File.CreateText(UrlAquivo);
                    Texto.Close();
                    Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.DataInicial, false);
                    Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.HoraInicial, false);
                    Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.DataFinal, false);
                    Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.HoraFinal, false);
                    if (Controles.ValidaMensagem("Registro cadastrado com sucesso! Deseja cadastrar um novo?", "Responda"))
                    {
                        LimpaCampos();
                    }
                    else
                    {
                        this.Close();
                        this.FormTelaIicial.AtualizaListaColaboradores();
                    }
                }
            }
            else
            {
                Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.DataInicial, true);
                Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.HoraInicial, false);
                Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.DataFinal, false);
                Controles.AlteraArquivo(UrlAquivo, ObjHorasExtras.HoraFinal, false);
                MessageBox.Show("Registro " + ObjHorasExtras.DataInicial + " alterado com sucesso!");
                this.Close();
                this.FormTelaIicial.AtualizaListaColaboradores();
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
