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

        public TelaInicial()
        {
            InitializeComponent();
            ComboBoxColaborador.Visible = false;
            GridPrincipal.Enabled = false;
            ButAdicionar.Enabled = false;
            ButAlterar.Enabled = false;
            ButRemover.Enabled = false;
            ButHorasExtras.Enabled = false;
            LabTotal.Enabled = false;
            LabValorTotal.Enabled = false;
            Controles teste = new Controles();
            teste.LerArquivo(".\\Dados\\Colaboradores.txt");
        }



        private void MenuColaboradores_Click(object sender, EventArgs e)
        {
            ComboBoxColaborador.Visible = false;
            GridPrincipal.Enabled = true;
            ButAdicionar.Enabled = true;
            ButAlterar.Enabled = true;
            ButRemover.Enabled = true;
            ButHorasExtras.Enabled = true;
            LabTotal.Enabled = true;
            LabValorTotal.Enabled = true;
            LabTotal.Text = "Total da folha: ";
            TipoGrid = "Colaborador";
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
            ComboBoxColaborador.Visible = true;
            GridPrincipal.Enabled = true;
            ButAdicionar.Enabled = false;
            ButAlterar.Enabled = true;
            ButRemover.Enabled = true;
            ButHorasExtras.Enabled = true;
            LabTotal.Enabled = true;
            LabValorTotal.Enabled = true;
            LabTotal.Text = "Total de Horas: ";
            TipoGrid = "HorasExtras";
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
            switch (TipoGrid)
            {
                case "Colaborador":
                    {
                        break;
                    }
                case "HorasExtras":
                    {
                        if (ComboBoxColaborador.SelectedItem.ToString() != "" && ComboBoxColaborador.SelectedItem.ToString() != "Todos")
                        {
                            if (Controles.ExisteHorasExtras(ComboBoxColaborador.SelectedItem.ToString()))
                            {
                                GridPrincipal.DataSource = HorasExtras.CarregaHorasExtras(ComboBoxColaborador.SelectedItem.ToString());
                            }
                            else
                            {
                                MessageBox.Show("O colaborador "+ ComboBoxColaborador.SelectedItem.ToString()  + " não possui horas extras!");
                            }
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
            if (GridPrincipal.CurrentRow.Cells[0].Value.ToString().Trim() != "")
            {
                switch (TipoGrid)
                {
                    case "Colaborador":
                        {
                            ItemSelecionado = GridPrincipal.CurrentRow.Cells[0].Value.ToString() + " " + GridPrincipal.CurrentRow.Cells[1].Value.ToString();
                            Form Colaboradores = new TelaColaboradores(ItemSelecionado, this);
                            Colaboradores.ShowDialog();
                            break;
                        }
                    case "HorasExtras":
                        {
                            ItemSelecionado = GridPrincipal.CurrentRow.Cells[1].Value.ToString() + " " + GridPrincipal.CurrentRow.Cells[2].Value.ToString();
                            ItemSelecionado = ItemSelecionado.Replace("/", "").Replace(":", "").Trim();
                            Form HorasExtras = new TelaHorasExtras(ItemSelecionado, this);
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
            switch (TipoGrid)
            {
                case "Colaborador":
                    {
                        try {
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

        //private void Click_GridPrincipal(object sender, EventArgs e)
        //{
        //    ItemSelecionado = GridPrincipal.CurrentRow.Cells[0].Value.ToString() + " " + GridPrincipal.CurrentRow.Cells[1].Value.ToString();
        //}

        #region Métodos

        public void AtualizaListaColaboradores() {
            decimal total;
            string ValorAtual;
            total = 0;
            GridPrincipal.DataSource = Colaborador.CarregaColaboradores();
            for (int i = 0; i <= GridPrincipal.Rows.Count-1 ; i++)
            {
                ValorAtual = Convert.ToString(GridPrincipal.Rows[i].Cells[2].Value);
                ValorAtual = ValorAtual.Replace("R$","").Trim();
                total = total + Convert.ToDecimal(ValorAtual);
            }
            LabValorTotal.Text = Controles.ConverteMoeda(total.ToString());

        }

        public void AtualizaListaHorasExtras()
        {
            GridPrincipal.DataSource = HorasExtras.CarregaHorasExtras();
            ComboBoxColaborador.DataSource = Colaborador.CarregaColaboradoresSomenteNomes();
            TotalizaHoras();
        }

        private void ExcluirHoraExtra()
        {
            ItemSelecionado = GridPrincipal.CurrentRow.Cells[1].Value.ToString() + " " + GridPrincipal.CurrentRow.Cells[2].Value.ToString();
            ItemSelecionado = ItemSelecionado.Replace("/", "").Replace(":", "").Trim();
            File.Delete(".\\Colaboradores\\" + GridPrincipal.CurrentRow.Cells[0].Value.ToString() + "\\Horas Extras\\" + ItemSelecionado + ".txt");
            AtualizaListaHorasExtras();
            MessageBox.Show("Horas Extras excluídas com sucesso!");
        }
        private void ExcluirColaborador()
        {
            ItemSelecionado = GridPrincipal.CurrentRow.Cells[0].Value.ToString() + " " + GridPrincipal.CurrentRow.Cells[1].Value.ToString();

            if (Controles.ExisteHorasExtras(ItemSelecionado))
            {
                if (Controles.ValidaMensagem("Este colaborador possui horas extras lançadas, deseja excluir mesmo assim?", "Exclusão de Colaborador"))
                {
                    Directory.Delete(".\\Colaboradores\\" + ItemSelecionado, true);
                    AtualizaListaColaboradores();
                    MessageBox.Show("Colaborador excluído com sucesso!");
                }
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
                Data1 = DateTime.Parse(Convert.ToString(GridPrincipal.Rows[i].Cells[1].Value) +" "+ Convert.ToString(GridPrincipal.Rows[i].Cells[2].Value));
                Data2 = DateTime.Parse(Convert.ToString(GridPrincipal.Rows[i].Cells[3].Value) +" "+ Convert.ToString(GridPrincipal.Rows[i].Cells[4].Value));
                Direrenca = Data2.Subtract(Data1);

                totalminutos = totalminutos + Direrenca.TotalMinutes;

            }
            TotalFinalHoras = TimeSpan.FromMinutes(totalminutos);
            TotalFinalMinutos = (totalminutos % 60) ;

            StringFinal = (TotalFinalHoras.Hours.ToString() + ":" + string.Format("{0:0,#}",Convert.ToDecimal(TotalFinalMinutos)));
            LabValorTotal.Text = StringFinal;
        }

        #endregion

        private void ButHorasExtras_Click(object sender, EventArgs e)
        {
            TelaHorasExtras Tela = new TelaHorasExtras(this);
            Tela.ShowDialog();
        }

        private void LabTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
