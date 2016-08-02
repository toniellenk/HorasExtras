﻿using System;
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
            LerAquivo(".\\Colaboradores\\" + ItemSelecionado + "\\Dados\\", ItemSelecionado + ".txt");

        }
        private void  TxtSalario_PercaFoco(object sender, EventArgs e)
        {
            if (TxtBxSalario.Text.Trim() != "") {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
                LabValor.Text = string.Format("{0:C}", Convert.ToDouble(TxtBxSalario.Text));
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
            ObjColaborador.Nome = TxtBxNome.Text;
            ObjColaborador.Sobrenome = TxtBxSobrenome.Text;
            ObjColaborador.Salario = LabValor.Text;

            Controles.CriaDiretorio(ObjColaborador.UrlDiretorio());
            CriaArquivo(ObjColaborador.UrlDiretorio(), "\\" + ObjColaborador.Nome + " " + ObjColaborador.Sobrenome + ".txt");


        }


        private void CriaArquivo(string UrlDiretorio, string NomeArquivo)
        {
            StreamWriter Texto;
            string UrlAquivo = UrlDiretorio + NomeArquivo;

            if (ItemSelecionado == null)
            {
                if (File.Exists(UrlAquivo))
                {
                    MessageBox.Show("Já Existe o registro " + ObjColaborador.Nome + ", utlize o direito Alterar");
                    this.Close();
                    this.FormTelaIicial.AtualizaListaColaboradores();
                }
                else {
                    Texto = File.CreateText(UrlAquivo);
                    Texto.Close();
                    Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Nome, false);
                    Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Sobrenome, false);
                    Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Salario, false);
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
                Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Nome, true);
                Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Sobrenome, false);
                Controles.AlteraArquivo(UrlAquivo, ObjColaborador.Salario, false);
                MessageBox.Show("Registro " + ObjColaborador.Nome + " alterado com sucesso!");
                this.Close();
                this.FormTelaIicial.AtualizaListaColaboradores();
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
                MessageBox.Show("Não existe o arquivo " + NomeArquivo + " no diretório " + UrlDiretorio);
            }
        }


        #endregion

        private void LabValor_Click(object sender, EventArgs e)
        {

        }
    }
}
