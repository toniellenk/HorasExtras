using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ControleHorasExtras
{
    public partial class TelaInicial : Form
    {
        string ItemSelecionado;
        public string TipoGrid;
        public bool Alteracao = false;
        public List<List<string>> ListagemDeDados = Controles.Dados(Controles.UrlDiretorio);

        public TelaInicial()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FechamentoTelaInicial);
            ComboBoxColaborador.Visible = false;
            GridPrincipal.Enabled = true;
            ButAdicionar.Enabled = false;
            ButAlterar.Enabled = false;
            ButRemover.Enabled = false;
            ButHorasExtras.Visible = false;
            LabTotal.Enabled = false;
            LabValorTotal.Enabled = false;
        }

        private void MenuColaboradores_Click(object sender, EventArgs e)
        {
            try
            {
                AtualizaListaColaboradores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi encontrado Colaboradores: " + ex);
            } 
        }

        private void MenuHorasExtras_Click(object sender, EventArgs e)
        {
            try
            {
                AtualizaListaHorasExtras();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi encontrado Horas Extras: " + ex);
            }
        }

        private void ButAdicionar_Click(object sender, EventArgs e)
        {
            Alteracao = false;
            switch (TipoGrid)
                {
                    case "Colaborador":
                        {
                            Form Colaboradores = new TelaColaboradores(this);
                            Colaboradores.ShowDialog();
                            break;
                        }
                    case "HorasExtras":
                        {
                            Form HorasExtras = new TelaHorasExtras(this);
                            HorasExtras.ShowDialog();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
        }

        private void ComboBoxColaborador_AlteraValor(object sender, EventArgs e)
        {
            string ColaboradorSelecionado = ComboBoxColaborador.SelectedItem.ToString();
            switch (TipoGrid)
            {
                case "Colaborador":
                    {
                        break;
                    }
                case "HorasExtras":
                    {
                        if (ColaboradorSelecionado != "" && ColaboradorSelecionado != "TODOS")
                        {
                                var valorLinha = ColaboradorSelecionado.Split('-');
                                GridPrincipal.DataSource = HorasExtras.CarregaHorasExtras(ListagemDeDados, valorLinha[0].Trim());
                        }
                        else
                        {
                            AtualizaListaHorasExtras();
                        }
                        TotalizaHoras();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void ButAlterar_Click(object sender, EventArgs e)
        {
            Alteracao = true;
            if (GridPrincipal.RowCount > 0)
            {
                switch (TipoGrid)
                {
                    case "Colaborador":
                        {
                            ItemSelecionado = GridPrincipal.CurrentRow.Cells[0].Value.ToString().Trim();
                            Form Colaboradores = new TelaColaboradores(ItemSelecionado, this);
                            Colaboradores.ShowDialog();
                            break;
                        }
                    case "HorasExtras":
                        {
                            Form HorasExtras = new TelaHorasExtras(this, true);
                            HorasExtras.ShowDialog();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione algum item na grade.");
            }
        }

        private void ButRemover_Click(object sender, EventArgs e)
        {
            Alteracao = false;
            if (GridPrincipal.RowCount > 0)
            {
                switch (TipoGrid)
                {
                    case "Colaborador":
                        {
                            try
                            {
                                ExcluirColaborador();
                                break;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Não foi possível excluir colaborador: " + ex);
                                break;
                            }
                        }
                    case "HorasExtras":
                        {
                            try
                            {
                                ExcluirHoraExtra();
                                break;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Não foi possível excluir Hora Extra: " + ex);
                                break;
                            }
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione algum item na grade.");
            }
        }

        private void ButHorasExtras_Click(object sender, EventArgs e)
        {
            Alteracao = false;
            if (GridPrincipal.RowCount > 0)
            {
                TelaHorasExtras Tela = new TelaHorasExtras(this);
                Tela.ShowDialog();
            }
            else {
                MessageBox.Show("Por favor, selecione algum colaborador!");
            }
        }

        private void FechamentoTelaInicial(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Controles.ValidaMensagem("Tem certeza que vai sair?", "Fechar aplicação"))
            {
                Controles.GravaDados(ListagemDeDados);
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

        }


        #region Métodos

        public void AtualizaListaColaboradores() {

            ComboBoxColaborador.Visible = false;
            GridPrincipal.Enabled = true;
            ButAdicionar.Enabled = true;
            ButAlterar.Enabled = true;
            ButRemover.Enabled = true;
            ButHorasExtras.Visible = true;
            LabTotal.Enabled = true;
            LabValorTotal.Enabled = true;
            LabTotal.Text = "Total da folha: ";
            TipoGrid = "Colaborador";

            GridPrincipal.DataSource = Colaborador.CarregaColaboradores(ListagemDeDados);
            LabValorTotal.Text = Controles.ConverteMoeda(Colaborador.SalarioTotal(ListagemDeDados).ToString());
        }

        public void AtualizaListaHorasExtras()
        {
            ComboBoxColaborador.Visible = true;
            GridPrincipal.Enabled = true;
            ButAdicionar.Enabled = true;
            ButAlterar.Enabled = true;
            ButRemover.Enabled = true;
            ButHorasExtras.Visible = false;
            LabTotal.Enabled = true;
            LabValorTotal.Enabled = true;
            LabTotal.Text = "Total de Horas: ";
            TipoGrid = "HorasExtras";
        
            GridPrincipal.DataSource = HorasExtras.CarregaHorasExtras(ListagemDeDados);     
            List<string> ListaColaboradores = Colaborador.CarregaColaboradoresSomenteIDeNomes(ListagemDeDados);
            ListaColaboradores.Insert(0, "TODOS");
            ComboBoxColaborador.DataSource = ListaColaboradores;
            TotalizaHoras();
        }

        private void ExcluirHoraExtra()
        {
            HorasExtras.ExcluiHoraExtra(ListagemDeDados,GridPrincipal.CurrentRow.Cells[0].Value.ToString().Trim());
            AtualizaListaHorasExtras();
            MessageBox.Show("Hora Extra excluída com sucesso!");
        }
        private void ExcluirColaborador()
        {
            ItemSelecionado = GridPrincipal.CurrentRow.Cells[0].Value.ToString();

            if (HorasExtras.CarregaHorasExtras(ListagemDeDados, ItemSelecionado).Count > 0)
            {
                MessageBox.Show("Este colaborador não pode ser excluído, porque possui horas extras lançadas.");
            }
            else
            {
                Colaborador.ExcluiColaborador(ListagemDeDados, ItemSelecionado);
                AtualizaListaColaboradores();
                MessageBox.Show("Colaborador excluído com sucesso!");
            }
        }


        private void TotalizaHoras()
        {
            DateTime Data1;
            DateTime Data2;
            TimeSpan Direrenca;
            string StringFinal;
            TimeSpan TotalFinalHoras;
            double TotalFinalMinutos;
            double totalminutos = 0;
            for (int i = 0; i <= GridPrincipal.Rows.Count - 1; i++)
            {
                Data1 = DateTime.Parse(Convert.ToString(GridPrincipal.Rows[i].Cells[3].Value) +" "+ Convert.ToString(GridPrincipal.Rows[i].Cells[4].Value));
                Data2 = DateTime.Parse(Convert.ToString(GridPrincipal.Rows[i].Cells[5].Value) +" "+ Convert.ToString(GridPrincipal.Rows[i].Cells[6].Value));
                Direrenca = Data2.Subtract(Data1);

                totalminutos = totalminutos + Direrenca.TotalMinutes;

            }
            TotalFinalHoras = TimeSpan.FromMinutes(totalminutos);
            TotalFinalMinutos = (totalminutos % 60) ;

            StringFinal = string.Format("{0:0,#}",Convert.ToDecimal(TotalFinalHoras.TotalHours)) + ":" + string.Format("{0:0,#}",Convert.ToDecimal(TotalFinalMinutos));
            LabValorTotal.Text = StringFinal;
        }

        #endregion




    }
}
