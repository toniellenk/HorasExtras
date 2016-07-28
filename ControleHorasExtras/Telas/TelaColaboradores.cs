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
    public partial class TelaColaboradores : Form
    {
        Colaborador ObjColaborador = new Colaborador();
        string ItemSelecionado;
        private TelaInicial FormTelaIicial;
        public TelaColaboradores()
        {
            InitializeComponent();
        }

        public TelaColaboradores(string ItemSelecionado)
        {
            this.ItemSelecionado = ItemSelecionado;
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
            this.ItemSelecionado = ItemSelecionado;
            InitializeComponent();
            LerAquivo(Colaborador.UrlDiretorio, ItemSelecionado + ".txt");
            
        }
        private void ButSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarColaborador();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);   
            }
        }

        #region Métodos

        private void LimpaCampos()
        {
            TxtBxNome.Clear();
            TxtBxSobrenome.Clear();
            TxtBxSalario.Clear();
        }
        private void SalvarColaborador()
        {
            ObjColaborador.Nome = TxtBxNome.Text;
            ObjColaborador.Sobrenome = TxtBxSobrenome.Text;
            ObjColaborador.Salario = TxtBxSalario.Text;            

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

            if (File.Exists(UrlAquivo))
            {
                if (ItemSelecionado == null)
                {
                    if (!ValidaMensagem("Já Existe o colaborador " + ObjColaborador.Nome + " deseja apenas altera-lo?", "Valida Colaborador"))
                    {
                        this.Close();
                        this.FormTelaIicial.AtualizaListaColaboradores();
                    }
                    else
                    {
                        Texto = File.CreateText(UrlAquivo);
                        Texto.Close();
                        AlteraArquivo(UrlAquivo, ObjColaborador.Nome);
                        AlteraArquivo(UrlAquivo, ObjColaborador.Sobrenome);
                        AlteraArquivo(UrlAquivo, ObjColaborador.Salario);
                        if (ValidaMensagem("Colaborador cadastrado com sucesso! Deseja cadastrar um novo colaborador?", "Responda"))
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
                    AlteraArquivo(UrlAquivo, ObjColaborador.Nome);
                    AlteraArquivo(UrlAquivo, ObjColaborador.Sobrenome);
                    AlteraArquivo(UrlAquivo, ObjColaborador.Salario);
                    MessageBox.Show("Colaborador alterado com sucesso!");
                    this.Close();
                    this.FormTelaIicial.AtualizaListaColaboradores();
                }
            }
        }
        private void AlteraArquivo(string UrlArquivo, string Conteudo)
        {
             StreamWriter Texto;

             Texto = File.AppendText(UrlArquivo);
             Texto.WriteLine(Conteudo);
             Texto.Close();

        }
        private Boolean ValidaMensagem(string Mensagem, string Titulo)
        {

            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(Mensagem, Titulo, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        private void LerAquivo(string UrlDiretorio, string NomeArquivo)
        {
            StreamReader Texto;
            string UrlAquivo = UrlDiretorio + NomeArquivo;

            if (File.Exists(UrlAquivo))
            {
                Texto = File.OpenText(UrlAquivo);
                TxtBxNome.Text = Texto.ReadLine();
                TxtBxSobrenome.Text = Texto.ReadLine();
                TxtBxSalario.Text = Texto.ReadLine();
                Texto.Close();
            }
            else
            {
                MessageBox.Show("Não existe o arquivo "+NomeArquivo+" no diretório "+ UrlDiretorio);
            }
        }

            #endregion

        }
}
