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
            switch (TipoGrid)
            {
                case "Colaborador":
                    {
                        Form Colaboradores = new TelaColaboradores(ItemSelecionado, this);
                        Colaboradores.ShowDialog();
                        break;
                    }
                case "HorasExtras":
                    {
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

        private void ButRemover_Click(object sender, EventArgs e)
        {
            switch (TipoGrid)
            {
                case "Colaborador":
                    {
                        File.Delete(".\\Colaboradores\\" + ItemSelecionado + "\\Dados\\" + ItemSelecionado + ".txt");
                        AtualizaListaColaboradores();
                        MessageBox.Show("Colaborador excluído com sucesso!");
                        break;
                    }
                case "HorasExtras":
                    {
                        File.Delete(".\\Colaboradores\\" + ItemSelecionado + "\\Hora Extras\\" + ItemSelecionado + ".txt");
                        AtualizaListaHorasExtras();
                        MessageBox.Show("Hora Extras excluídas com sucesso!");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        private void Click_GridPrincipal(object sender, EventArgs e)
        {
            ItemSelecionado = GridPrincipal.CurrentRow.Cells[0].Value.ToString() + " " + GridPrincipal.CurrentRow.Cells[1].Value.ToString();
        }

        #region Métodos

        public void AtualizaListaColaboradores() {
            Colaborador ListaColaboradores = new Colaborador();
            GridPrincipal.DataSource = ListaColaboradores.CarregaColaboradores();
        }

        public void AtualizaListaHorasExtras()
        {
            HorasExtras ListaHorasExtras = new HorasExtras();
            GridPrincipal.DataSource = ListaHorasExtras.CarregaHorasExtras();
        }
        #endregion






    }
}
