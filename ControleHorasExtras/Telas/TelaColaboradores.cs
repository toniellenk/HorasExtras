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
        string ItemSelecionado;
        private TelaInicial FormTelaIicial;
        public DataTable DtColaborador = new DataTable();
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
            //     LerArquivo(ObjColaborador.UrlDiretorio);

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
                SalvarColaborador();
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
        }

        private void SalvarColaborador()
        {
            ObjColaborador.Id = Convert.ToString(Colaborador.CarregaColaboradoresSomenteIDeNomes(this.FormTelaIicial.ListagemColaborador).Count+1);
            ObjColaborador.Nome = TxtBxNome.Text;
            ObjColaborador.Sobrenome = TxtBxSobrenome.Text;
            ObjColaborador.Salario = TxtBxSalario.Text;

            AlteraLista();


        }


        private void AlteraLista()
        {
            Colaborador.AdicionaColaborador(this.FormTelaIicial.ListagemColaborador, ObjColaborador);
            this.Close();
            this.FormTelaIicial.AtualizaListaColaboradores();

        }

        //    public DataTable LerArquivo(string UrlText)
        //    {
        //        StreamReader Texto;
        //        DtColaborador. = "dsad";
        //if (File.Exists(UrlText))
        //    {
        //        Texto = File.OpenText(UrlText);               
        //        Texto.Close();


        // }
        //        else
        //        {
        //        //    MessageBox.Show("Não existe o arquivo " + NomeArquivo + " no diretório " + UrlDiretorio);
        //        }
        //    return DtColaborador;
        //}


        #endregion

        //private void LabValor_Click(object sender, EventArgs e)
        //{

        //}
    }
}

