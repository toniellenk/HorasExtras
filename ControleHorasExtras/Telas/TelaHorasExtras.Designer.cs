﻿namespace ControleHorasExtras
{
    partial class TelaHorasExtras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ButSalvar = new System.Windows.Forms.Button();
            this.TxBxDtaInicial = new System.Windows.Forms.MaskedTextBox();
            this.TxBxDtaFinal = new System.Windows.Forms.MaskedTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxBxDtaInicial);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 39);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data e Hora Inicial";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxBxDtaFinal);
            this.groupBox2.Location = new System.Drawing.Point(12, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(117, 39);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data e Hora final";
            // 
            // ButSalvar
            // 
            this.ButSalvar.Location = new System.Drawing.Point(122, 202);
            this.ButSalvar.Name = "ButSalvar";
            this.ButSalvar.Size = new System.Drawing.Size(75, 23);
            this.ButSalvar.TabIndex = 3;
            this.ButSalvar.Text = "Salvar";
            this.ButSalvar.UseVisualStyleBackColor = true;
            this.ButSalvar.Click += new System.EventHandler(this.ButSalvar_Click);
            // 
            // TxBxDtaInicial
            // 
            this.TxBxDtaInicial.Location = new System.Drawing.Point(7, 13);
            this.TxBxDtaInicial.Mask = "00/00/0000 90:00";
            this.TxBxDtaInicial.Name = "TxBxDtaInicial";
            this.TxBxDtaInicial.Size = new System.Drawing.Size(103, 20);
            this.TxBxDtaInicial.TabIndex = 1;
            this.TxBxDtaInicial.ValidatingType = typeof(System.DateTime);
            // 
            // TxBxDtaFinal
            // 
            this.TxBxDtaFinal.Location = new System.Drawing.Point(7, 13);
            this.TxBxDtaFinal.Mask = "00/00/0000 90:00";
            this.TxBxDtaFinal.Name = "TxBxDtaFinal";
            this.TxBxDtaFinal.Size = new System.Drawing.Size(103, 20);
            this.TxBxDtaFinal.TabIndex = 2;
            this.TxBxDtaFinal.ValidatingType = typeof(System.DateTime);
            this.TxBxDtaFinal.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox2_MaskInputRejected);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(12, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(296, 45);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Colaborador";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TelaHorasExtras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 249);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.ButSalvar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaHorasExtras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Horas Extras";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TelaHorasExtras_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ButSalvar;
        private System.Windows.Forms.MaskedTextBox TxBxDtaInicial;
        private System.Windows.Forms.MaskedTextBox TxBxDtaFinal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}