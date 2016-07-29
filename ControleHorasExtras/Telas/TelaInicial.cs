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

        private void ButAdicionar_Click(object sender, EventArgs e)
        {
            Form Colaboradores = new TelaHorasExtras(this);
            Colaboradores.ShowDialog();
        }

        private void MenuColaboradores_Click(object sender, EventArgs e)
        {
            switch (TipoGrid) { 
            case "Colaborador":
                {
                    AtualizaListaColaboradores();
                    break;
                }
            case "HorasExtras":
                {
                    AtualizaListaColaboradores();
                    break;
                }
            default: {
                        break;
                    } 
            }

        }

        #region Métodos

        public void AtualizaListaColaboradores() {
            Colaborador ListaColaboradores = new Colaborador();
            GridPrincipal.DataSource = ListaColaboradores.CarregaColaboradores();
        }

        #endregion

        private void ButAlterar_Click(object sender, EventArgs e)
        {
            ItemSelecionado = GridPrincipal.CurrentRow.Cells[0].Value.ToString();
            Form Colaboradores = new TelaHorasExtras(ItemSelecionado, this);
            Colaboradores.ShowDialog();
        }

        private void ButRemover_Click(object sender, EventArgs e)
        {
            File.Delete(Colaborador.UrlDiretorio + ItemSelecionado + ".txt");
            MessageBox.Show("Colaborador excluído com sucesso!");
        }


    }
}
