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
        string TipoGrid;

        public TelaInicial()
        {
            InitializeComponent();
        }



        private void MenuColaboradores_Click(object sender, EventArgs e)
        {
            ButAdicionar.Enabled = true;
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
            ButAdicionar.Enabled = false;
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
            LabTotal.Text = "Total da folha: ";
            GridPrincipal.DataSource = Colaborador.CarregaColaboradores();
            for (int i = 0; i <= GridPrincipal.Rows.Count-1 ; i++)
            {
                ValorAtual = Convert.ToString(GridPrincipal.Rows[i].Cells[2].Value);
                ValorAtual = ValorAtual.Replace("R$","").Replace(".", "").Trim();
                total = total + Convert.ToDecimal(ValorAtual);
            }
            LabValorTotal.Text = total.ToString();

        }

        public void AtualizaListaHorasExtras()
        {
            GridPrincipal.DataSource = HorasExtras.CarregaHorasExtras();
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
            if (Directory.Exists(".\\Colaboradores\\" + ItemSelecionado + "\\Horas Extras\\"))
            {
                if (Directory.EnumerateFileSystemEntries(".\\Colaboradores\\" + ItemSelecionado + "\\Horas Extras\\", "*.txt").Any())
                {
                    if (Controles.ValidaMensagem("Este colaborador possui horas extras lançadas, deseja excluir mesmo assim?", "Exclusão de Colaborador"))
                    {

                        Directory.Delete(".\\Colaboradores\\" + ItemSelecionado, true);
                        AtualizaListaColaboradores();
                        MessageBox.Show("Colaborador excluído com sucesso!");
                    }
                }
                else
                {
                    Directory.Delete(".\\Colaboradores\\" + ItemSelecionado, true);
                    AtualizaListaColaboradores();
                    MessageBox.Show("Colaborador excluído com sucesso!");
                }
            }
            else
            {
                Directory.Delete(".\\Colaboradores\\" + ItemSelecionado, true);
                AtualizaListaColaboradores();
                MessageBox.Show("Colaborador excluído com sucesso!");
            }
        }




        #endregion

        private void ButHorasExtras_Click(object sender, EventArgs e)
        {
            TelaHorasExtras Tela = new TelaHorasExtras(this);
            Tela.ShowDialog();
        }
    }
}
