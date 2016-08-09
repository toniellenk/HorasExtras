namespace ControleHorasExtras
{
    partial class TelaColaboradores
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
            this.TxtBxNome = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtBxSobrenome = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtBxSalario = new System.Windows.Forms.TextBox();
            this.ButSalvar = new System.Windows.Forms.Button();
            this.LabValor = new System.Windows.Forms.Label();
            this.LabId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtBxNome);
            this.groupBox1.Location = new System.Drawing.Point(60, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 39);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nome";
            // 
            // TxtBxNome
            // 
            this.TxtBxNome.Location = new System.Drawing.Point(7, 13);
            this.TxtBxNome.Name = "TxtBxNome";
            this.TxtBxNome.Size = new System.Drawing.Size(182, 20);
            this.TxtBxNome.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtBxSobrenome);
            this.groupBox2.Location = new System.Drawing.Point(60, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 39);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sobrenome";
            // 
            // TxtBxSobrenome
            // 
            this.TxtBxSobrenome.Location = new System.Drawing.Point(6, 13);
            this.TxtBxSobrenome.Name = "TxtBxSobrenome";
            this.TxtBxSobrenome.Size = new System.Drawing.Size(308, 20);
            this.TxtBxSobrenome.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtBxSalario);
            this.groupBox3.Location = new System.Drawing.Point(60, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(99, 39);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Salário";
            // 
            // TxtBxSalario
            // 
            this.TxtBxSalario.Location = new System.Drawing.Point(6, 13);
            this.TxtBxSalario.Name = "TxtBxSalario";
            this.TxtBxSalario.Size = new System.Drawing.Size(87, 20);
            this.TxtBxSalario.TabIndex = 0;
            this.TxtBxSalario.LostFocus += new System.EventHandler(this.TxtSalario_PercaFoco);
            // 
            // ButSalvar
            // 
            this.ButSalvar.Location = new System.Drawing.Point(180, 242);
            this.ButSalvar.Name = "ButSalvar";
            this.ButSalvar.Size = new System.Drawing.Size(75, 23);
            this.ButSalvar.TabIndex = 3;
            this.ButSalvar.Text = "Salvar";
            this.ButSalvar.UseVisualStyleBackColor = true;
            this.ButSalvar.Click += new System.EventHandler(this.ButSalvar_Click);
            // 
            // LabValor
            // 
            this.LabValor.AutoSize = true;
            this.LabValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabValor.ForeColor = System.Drawing.Color.Red;
            this.LabValor.Location = new System.Drawing.Point(165, 182);
            this.LabValor.Name = "LabValor";
            this.LabValor.Size = new System.Drawing.Size(0, 13);
            this.LabValor.TabIndex = 4;
            // 
            // LabId
            // 
            this.LabId.AutoSize = true;
            this.LabId.Location = new System.Drawing.Point(67, 38);
            this.LabId.Name = "LabId";
            this.LabId.Size = new System.Drawing.Size(24, 13);
            this.LabId.TabIndex = 5;
            this.LabId.Text = "ID: ";
            // 
            // TelaColaboradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 325);
            this.Controls.Add(this.LabId);
            this.Controls.Add(this.LabValor);
            this.Controls.Add(this.ButSalvar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TelaColaboradores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Colaborador";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtBxNome;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtBxSobrenome;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ButSalvar;
        private System.Windows.Forms.TextBox TxtBxSalario;
        private System.Windows.Forms.Label LabValor;
        private System.Windows.Forms.Label LabId;
    }
}