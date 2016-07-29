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
        Colaborador ObjColaborador = new Colaborador();
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
            Controles.LerAquivo(Colaborador.UrlDiretorio, ItemSelecionado + ".txt");            
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
            ObjColaborador.Nome = "";
            ObjColaborador.Sobrenome = "";
            ObjColaborador.Salario = "";            

            CriaDiretorio(Colaborador.UrlDiretorio);
            CriaArquivo(Colaborador.UrlDiretorio, ObjColaborador.Nome + ".txt");


        }

        private void CriaDiretorio(string UrlDiretorio){
            if (!Directory.Exists(UrlDiretorio))
            {
                Directory.CreateDirectory(UrlDiretorio);
            }
        }

        private void CriaArquivo(string UrlDiretorio, string NomeArquivo)
        {
            StreamWriter Texto;
            string UrlAquivo = UrlDiretorio + NomeArquivo;

                if (ItemSelecionado == null)
                {
                    if ((File.Exists(UrlAquivo)) && (!Controles.ValidaMensagem("Já Existe o registro " + ObjColaborador.Nome + " deseja apenas altera-lo?", "Valida Colaborador")))
                    {
                        this.Close();
                        this.FormTelaIicial.AtualizaListaColaboradores();
                    }
                    else { 
                                Texto = File.CreateText(UrlAquivo);
                                Texto.Close();
                                Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Nome, true);
                                Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Sobrenome, true);
                                Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Salario, true);
                                if (Controles.ValidaMensagem("Registro cadastrado com sucesso! Deseja cadastrar um novo?", "Responda"))
                                {
                                    LimpaCampos();
                                }
                                else {
                                    this.Close();
                                    this.FormTelaIicial.AtualizaListaColaboradores();
                                }
                    }
                }
                else
                {
                    File.Delete(UrlAquivo);
                    Texto = File.CreateText(UrlAquivo);
                    Texto.Close();
                    Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Nome, true);
                    Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Sobrenome, true);
                    Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Salario, true);
                    MessageBox.Show("Registro " +ObjColaborador.Nome+ " alterado com sucesso!");
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

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Colaborador.UrlDiretorio;
            openFileDialog1.ShowDialog();
        }
    }
}
